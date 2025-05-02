using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float spawnX;
    public float spawnY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnX = rb.position.x;
        spawnY = rb.position.y;
    }

    void Update()
    {
        if (rb.position.y < -4)
        {
            rb.position = new Vector2(spawnX, spawnY);
            rb.angularVelocity = 0;
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if
        (
            collision.gameObject.name.Contains("platform") == false &&
            collision.gameObject.name.Contains("leaf") == false &&
            collision.gameObject.name.Contains("Bird") == false
        )
        {
            rb.position = new Vector2(spawnX, spawnY);
            rb.angularVelocity = 0;
            rb.linearVelocity = Vector2.zero;
        }
           
    }
}
