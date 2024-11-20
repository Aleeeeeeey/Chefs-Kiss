using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);

        DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);

        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);
    }
}
