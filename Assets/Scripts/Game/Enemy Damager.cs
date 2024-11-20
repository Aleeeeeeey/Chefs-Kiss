using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifetime, growSpeed = 5f;
    private Vector3 targetSize;

    public bool shouldKnockBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy(gameObject, lifetime);

        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);

        lifetime -= Time.deltaTime;

        if ( lifetime <= 0)
        {
            targetSize = Vector3.zero;

            if ( transform.localScale.x == 0f )
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockBack);
        }
    }
}
