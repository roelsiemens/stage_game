using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public int Health = 3;

    private float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Health -= 1;
        }

        if (collision.CompareTag("AsteroidBorder"))
        {
            Destroy(gameObject);
        }
    }
}
