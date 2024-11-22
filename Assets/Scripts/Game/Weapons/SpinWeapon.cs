using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed;

    public Transform holder, rollerpinToSpawn;

    public float timeBetweenSpawn;
    private float spawnCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (rotateSpeed * Time.deltaTime));

        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawn;

            Instantiate(rollerpinToSpawn, rollerpinToSpawn.position, rollerpinToSpawn.rotation, holder).gameObject.SetActive(true);
        }
    }
}
