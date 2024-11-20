using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Enemyspawner : MonoBehaviour
{
    public GameObject bananaSpiderPrefab;
    public GameObject steakSlugPrefab;

    public float timeToSpawn; //Sets the timer
    private float spawnCounter; //IS the timer

    public Transform minSpawn, maxSpawn;

    private float despawnDistance;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public int checkPerFrame;
    private int enemyToCheck;

    private void Start()
    {
        spawnCounter = timeToSpawn;

        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;
    }

    void Update()
    {
        //ticks down per second
        spawnCounter -= Time.deltaTime;

        if(spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;

            GameObject newEnemy = Instantiate(bananaSpiderPrefab, SelectSpawnpoint(), transform.rotation);

            spawnedEnemies.Add(newEnemy);
        }

        int checkTarget = enemyToCheck + checkPerFrame;

        while (enemyToCheck < checkTarget)
        {
            if(enemyToCheck < spawnedEnemies.Count)
            {
                if (spawnedEnemies[enemyToCheck] != null)
                {
                    if(Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance)
                    {
                        Destroy(spawnedEnemies[enemyToCheck]);

                        spawnedEnemies.RemoveAt(enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }

    public Vector3 SelectSpawnpoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }

            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }

        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }

            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }

        return spawnPoint;
    }
}
