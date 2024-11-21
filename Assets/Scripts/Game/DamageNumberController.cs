using UnityEngine;
using System.Collections.Generic;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamageNumber> numberPool = new List<DamageNumber>();

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

        //DamageNumber newDamage = Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas);

        DamageNumber newDamage = GetFromPool();

        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);

        newDamage.transform.position = location;
    }

    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutput = null;

        if (numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }
        else
        {
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }
        return numberToOutput;
    }

    public void PlaceInPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);

        numberPool.Add(numberToPlace);
    }
}
