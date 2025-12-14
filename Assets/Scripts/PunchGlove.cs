using UnityEngine;

public class PunchGlove : MonoBehaviour
{
    public float punchForce = 500f;
    public Vector2 punchDirection = new Vector2(1, 1);
    public float destroyDelay = 2f;
    public int punches = 0;
    public int numOfEnemies = 20;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 forceDir = punchDirection.normalized;
            rb.AddForce(forceDir * punchForce);

            Destroy(collision.gameObject, destroyDelay);

            punches++;

        }
    }

    private void Update()
    {
        if (punches >= numOfEnemies)
        {
            PunchManager.Instance.endSequence();
        }
    }
}
