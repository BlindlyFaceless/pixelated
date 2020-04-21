using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{

    public float patrolRadius;

    private Animator anim;

    public Transform Target;

    Transform player;
    NavMeshAgent agent;

    public static float AiDamage = 1f;

    public float range;
    public Camera fpsCam;

    bool IsShooting = false;




    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();


        anim = GetComponent<Animator>();

        agent.SetDestination(Target.position);
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector3.Distance(player.position, transform.position);

        float DomeDist = Vector3.Distance(Target.position, transform.position);

        agent.SetDestination(Target.position);

        if (distance <= patrolRadius)
        {
            agent.SetDestination(player.position);
            anim.SetBool("Walking", true);
            LookAtPlayer();

            if (distance <= agent.stoppingDistance)
            {

            }
            else
            {
                anim.SetBool("DoneAiming", false);
                anim.SetBool("Walking", true);
                LookAtDome();
                agent.SetDestination(Target.position);

            }
        }

        if (DomeDist <= agent.stoppingDistance)
        {
            anim.SetBool("DoneAiming", true);
            LookAtDome();
        }

    }

    void LookAtPlayer()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


        if (distance <= agent.stoppingDistance && IsShooting == false)
        {

            StartCoroutine(AlienShoot());

        }

    }

    void LookAtDome()
    {

        float DomeDist = Vector3.Distance(Target.position, transform.position);

        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);
    }


    IEnumerator AlienShoot()
    {
        IsShooting = true;
        anim.SetBool("DoneAiming", true);

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                Health.health -= 1;
            }
        }
        yield return new WaitForSeconds(2f);
        IsShooting = false;
    }

}