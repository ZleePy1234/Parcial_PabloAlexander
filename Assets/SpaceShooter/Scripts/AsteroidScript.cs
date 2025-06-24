using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private Rigidbody rb;

    private AsteroidSpawnerScript asteroidSpawnerScript;
    private SoundManager soundManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        asteroidSpawnerScript = GameObject.FindWithTag("Spawner").GetComponent<AsteroidSpawnerScript>();
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }
    void Start()
    {
        speed = asteroidSpawnerScript.asteroidSpeed;
        StartCoroutine(AsteroidSpawned());
    }
    
    IEnumerator AsteroidSpawned()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.down * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();
            playerScript.DamagePlayer();
            soundManager.PlayDamage();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Attack"))
        {
            Destroy(collision.gameObject);
            PlayerScript playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
            playerScript.asteroidsDestroyed++;
            soundManager.PlayExplosion();
            Destroy(gameObject);
        }
    }
}
