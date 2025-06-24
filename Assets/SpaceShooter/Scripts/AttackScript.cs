using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour
{
    public float attackSpeed;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.up * attackSpeed * Time.fixedDeltaTime);
    }
    // Uitilizando moveposition en fixedupdate para asegurar que la colision funcione lo mejor posible.
}
