using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float kills;
    public float health;
    public float deathTimer;
    private Animator anim;
    bool enemyCounted = false;

    public AudioSource DeathTalk;
    public AudioSource GunHit;

    bool dead = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        GunHit.Play();
        if (health <= 0f && dead == false)
        {
            WaveSpawner.enemyCount -= 1;
            StartCoroutine(Death());
            anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            if (enemyCounted == false)
            {

                enemyCounted = true;
            }
        }
    }

    IEnumerator Death()
    {
        dead = true;
        DeathTalk.Play();
        anim = GetComponent<Animator>();
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(deathTimer);

        Destroy(gameObject);
        dead = false;

        kills += 10;
    }
}
