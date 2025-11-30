using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed = 2;

    public int health = 1;


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}

