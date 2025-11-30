using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public Transform spawnArea;

    public GameObject healthPowerUp;
    public GameObject shieldPowerUp;

    public int randomizer = 0;

    public float spawnTimer = 10;

    public bool canSpawn = false;

    System.Random rand = new System.Random();

    void Update()
    {
        if (canSpawn)
        {
            Randomizer();
        }

        if (!canSpawn)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer < 0)
        {
            canSpawn = true;
            spawnTimer = 10;
        }
    }

    public void Randomizer()
    {
        randomizer = rand.Next(0, 2);
        Spawner();
    }

    public void Spawner()
    {
        if (randomizer == 0)
        {
            Instantiate(healthPowerUp, spawnArea.position, spawnArea.rotation);
            canSpawn = false;
        }
        else if (randomizer == 1)
        {
            Instantiate(shieldPowerUp, spawnArea.position, spawnArea.rotation);
            canSpawn = false;
        }
    }
}