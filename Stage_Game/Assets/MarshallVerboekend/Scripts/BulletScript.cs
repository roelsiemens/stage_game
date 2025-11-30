using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid") || collision.CompareTag("BulletBorder"))
        {
            Destroy(gameObject);
        }
    }
}