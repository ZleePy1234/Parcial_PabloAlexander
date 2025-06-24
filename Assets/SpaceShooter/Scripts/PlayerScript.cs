using System.Collections;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [Header("Player Stats")]
    [Space(10)]
    [Tooltip("Vida del jugador")]
    [Range(0, 3)]
    public int health;
    [Tooltip("Velocidad del jugador")]
    [Range(0, 10)]
    public float speed;
    public float damageCooldown;
    private bool canTakeDamage = true;

    private float horizontal;

    [Header("Actions Stats")]
    [Space(10)]

    public float attackCooldown;
    private bool canAttack = true;
    public GameObject AttackPrefab;

    public Transform AttackSpawn;
    [HideInInspector] public int asteroidsDestroyed;

    private SoundManager soundManager;

    void Update()
    {
        ControlsUpdate(); // Inputs y Movimiento
        if (health <= 0)
        {
            Debug.Log("Game Over");
            EndGameScript endGameScript = GameObject.FindWithTag("GameOver").GetComponent<EndGameScript>();
            endGameScript.GameOver();
        }
    }

    void Awake()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void ControlsUpdate()
    {
        PlayerInputs();
        Movement();
    }
    void PlayerInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(AttackRoutine());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pausa
        }
    }
    void Movement()
    {
        Vector3 movement = new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        AreaLimit();
    }

    public void DamagePlayer()
    {
        if (!canTakeDamage)
        {
            return;
        }
        else
        {
            health--;
            canTakeDamage = false;
            Invoke(nameof(ResetDamageCooldown), damageCooldown);
            Debug.Log("Player damaged! Current health: " + health);
        }
    }

    private void ResetDamageCooldown()
    {
        canTakeDamage = true;
    }
    IEnumerator AttackRoutine()
    {
        if (!canAttack)
        {
            yield break;
        }
        canAttack = false;
        StartCoroutine(AttackCooldown());
        Attack();
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void Attack()
    {
        Instantiate(AttackPrefab, AttackSpawn.position, Quaternion.identity);
        soundManager.PlayFire();
    }

    void AreaLimit()
    {
        if (transform.position.x < -4.23f)
        {
            transform.position = new Vector3(-4.23f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 9.04f)
        {
            transform.position = new Vector3(9.04f, transform.position.y, transform.position.z);
        }
    }
}
