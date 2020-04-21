using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObject enemy;
    public int xPos;
    public int zPos;
    public static int enemyCount;
    public float MaxEnemyCount;

    public float DownTime; //Time between levels

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    void FixedUpdate()
    {
        if (enemyCount <= 0 /*&& Input.GetKeyDown(KeyCode.T)*/)
        {
            MaxEnemyCount += 2;
            StartCoroutine(EnemySpawner());

        }

        Debug.Log(enemyCount);
    }

    IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(10f);
        MaxEnemyCount += 2;

        enemyCount += 1;
        xPos = Random.Range(-11, 12);
        zPos = Random.Range(-12, 12);
        Instantiate(enemy, new Vector3(xPos, 43, zPos), Quaternion.identity);
        yield return new WaitForSeconds(1f);

    }


    IEnumerator EnemyDrop()
    {
        MaxEnemyCount += 2;

        while (enemyCount < MaxEnemyCount)
        {
            enemyCount += 1;
            xPos = Random.Range(-11, 12);
            zPos = Random.Range(-12, 12);
            Instantiate(enemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

}
