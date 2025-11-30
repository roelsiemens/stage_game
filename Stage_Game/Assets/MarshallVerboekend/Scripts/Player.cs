using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canShoot = true;

    public float liveTimer = 0;
    public float speed = 5;
    public float shootCooldown = 1;

    public int health = 3;
    public int shield = 0;

    public TextMeshProUGUI timerText;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public GameObject Shield1;
    public GameObject Shield2;

    public GameObject Bullet;
    public Transform BulletSpawn;

    void Update()
    {
        timerText.text = liveTimer.ToString();

        liveTimer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(liveTimer / 60f);
        int seconds = Mathf.FloorToInt(liveTimer % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        Movement();
        IconChecker();
        Shooting();

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Shooting()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
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

    public void Movement()
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
    }

    public void IconChecker()
    {
        if (health == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        else if (health == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        else if (health == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }

        if (shield == 2)
        {
            Shield1.SetActive(true);
            Shield2.SetActive(true);
        }
        else if (shield == 1)
        {
            Shield1.SetActive(true);
            Shield2.SetActive(false);
        }
        else if (shield == 0)
        {
            Shield1.SetActive(false);
            Shield2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShieldPickUp") && shield < 2)
        {
            shield++;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("ShieldPickUp") && shield >= 2)
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("HealthPickUp") && health < 3)
        {
            health++;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("HealthPickUp") && health >= 3)
        {
            Destroy(collision.gameObject);
        }
    }
}