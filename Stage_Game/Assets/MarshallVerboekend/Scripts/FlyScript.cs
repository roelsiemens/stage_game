using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public bool canShoot = true;

    public int health = 3;

    public float shootCooldown = 1f;

    private float speed = 5f;

    public GameObject Bullet;

    public Transform spawnLocation;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        ShootCheck();
    }

    public void ShootCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Instantiate(Bullet, spawnLocation.position, spawnLocation.rotation);
            canShoot = false;
        }

        if (!canShoot)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (shootCooldown <= 0)
        {
            canShoot = true;
            shootCooldown = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
