//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float health = 9f;
    public float numOfHearts;

    public Image[] hearts;


    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            health = 0;

        if (health <= 0)
        {
            FindObjectOfType<GameManagment>().EndGame();
        }

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        health -= AiEnemy.AiDamage;
    }

}