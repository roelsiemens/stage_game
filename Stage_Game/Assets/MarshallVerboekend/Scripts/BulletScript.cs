using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("BulletBorder"))
        {
            Destroy(gameObject);
        }
    }
}
