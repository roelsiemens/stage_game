using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] Asteroids;
    public Transform[] SpawnLocation;
    private GameObject SpawningAsteriod;
    private Transform SpawningLocation;

    public Vector2 spawnArea = new Vector2(10f, 10f);

    public bool canSpawn = true;

    public float spawnTimer = 1;

    void Update()
    {
        SpawnCheck();
    }

    public void SpawnCheck()
    {
        if (canSpawn && spawnTimer > 0)
        {
            canSpawn = false;
            Randomizer();
            Instantiate(SpawningAsteriod, SpawningLocation.position, SpawningLocation.rotation);
        }

        if (!canSpawn)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer <= 0)
        {
            canSpawn = true;
            spawnTimer = 1;
        }
    }

    public void Randomizer()
    {
        if (Asteroids.Length > 0)
        {
            int index = Random.Range(0, Asteroids.Length);
            SpawningAsteriod = Asteroids[index];


            float randomX = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
            float randomY = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);

            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
            SpawningLocation = null;

            Instantiate(SpawningAsteriod, randomPosition, Quaternion.identity);
        }
    }
}
