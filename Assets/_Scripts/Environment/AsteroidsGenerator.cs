using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour
{
    [SerializeField]
    private AsteroidConfig[] asteroids;

    public int asteroidsCount;
    public float spawnRange;

    private void Awake()
    {
        for(int i = 0; i < asteroidsCount; i++)
        {
            AsteroidConfig asteroidConfig = asteroids[Random.Range(0, asteroids.Length)];
            Vector3 asteroidPosition = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            Asteroid asteroid = Instantiate(asteroidConfig.prefab, asteroidPosition, Quaternion.identity).GetComponent<Asteroid>();
            float asteroidSize = Random.Range(asteroidConfig.scaleRange.x, asteroidConfig.scaleRange.y);
            asteroid.Initialize(asteroidSize, asteroidConfig.angularVelocityRange);
        }
    }
}
