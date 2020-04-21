
using UnityEngine;

public class Knifing : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;

    public Camera fpsCam;


    private float nextTimetoFire = 0f;


    // Update is called once per frame
    void Update()
    {
      

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time * 1f / fireRate;
            
            Shoot();
        }
    }

    void Shoot()
    {

      

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

          
        }
    }
}
