using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject bananaSpiderPrefab;
    public GameObject steakSlugPrefab;

    public float timeToSpawn; //Sets the timer
    private float spawnCounter; //IS the timer

    public Transform minSpawn, maxSpawn;

    private void Start()
    {
        spawnCounter = timeToSpawn;
    }

    void Update()
    {
        //ticks down once per second
        spawnCounter -= Time.deltaTime;

        if(spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;

            Instantiate(bananaSpiderPrefab, SelectSpawnpoint(), transform.rotation);
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
