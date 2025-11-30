using UnityEngine;

public class DroppingItemScript : MonoBehaviour
{
    public float speed = 3;
    public float despawnTimer = 10;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        despawnTimer -= Time.deltaTime;

        if (despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}