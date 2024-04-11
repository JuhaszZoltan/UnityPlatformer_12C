using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    [SerializeField] private float damageRate = 1f;
    [SerializeField] private float pushForce = 20f;

    private float nextDamage;

    private void Start()
    {
        nextDamage = 0f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            nextDamage = Time.time + damageRate;
            PushBack(other.transform);
        }
    }

    private void PushBack(Transform playerTransform)
    {
        Rigidbody2D playerRigidbody = playerTransform.gameObject.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(transform.up * pushForce, ForceMode2D.Impulse);
    }
}
