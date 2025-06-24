using UnityEngine;
using System.Collections;

public class AsteroidSpawnerScript : MonoBehaviour
{
    public float asteroidSpeed;
    public float Xmax;
    public float Xmin;
    public float Ymax;
    public float Ymin;
    public float asteroidCooldown;
    public GameObject AsteroidPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnAsteroids());
        StartCoroutine(AsteroidRampUp());
        StartCoroutine(AsteroidSpeedRampUp());

    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            float randomX = Random.Range(Xmin, Xmax);
            float randomY = Random.Range(Ymin, Ymax);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            Instantiate(AsteroidPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(asteroidCooldown);
        }
    }
    IEnumerator AsteroidRampUp()
    {
        while (asteroidCooldown > 0.1f)
        {
            asteroidCooldown = Mathf.Max(0.1f, asteroidCooldown - 0.1f);
            yield return new WaitForSeconds(10f);
        }
    }
    IEnumerator AsteroidSpeedRampUp()
    {
        while (asteroidSpeed < 10f)
        {
            asteroidSpeed += 0.1f;
            yield return new WaitForSeconds(10f);
        }
    }
}
