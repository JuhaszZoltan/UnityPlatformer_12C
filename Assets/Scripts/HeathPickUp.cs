using UnityEngine;

public class HeathPickUp : MonoBehaviour
{
    [SerializeField] private float healingAmmount = 3f;

    private bool pickedUp;

    private void Awake() => pickedUp = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!pickedUp && other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.GetHealing(healingAmmount);
            pickedUp = true;
            Destroy(gameObject);
        }
    }
}
