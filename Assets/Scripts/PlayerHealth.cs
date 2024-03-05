using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private GameObject bloodDropsFX;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image damageIndicator;
    [SerializeField] private float dmgSmoothTime = 1f;

    //private Color dmgColor = new(0f, 0f, 0f, 1f);
    private float currentHealth;
    private bool getDamage;

    private void Start()
    {
        getDamage = false;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    private void Update()
    {
        if (getDamage)
        {
            damageIndicator.color = new Color(255, 255, 255, 1);
        }
        else damageIndicator.color = Color.Lerp(
            damageIndicator.color,
            new(255, 255, 255, 0),
            dmgSmoothTime * Time.deltaTime);
        getDamage = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        getDamage = true;
        healthBar.value = currentHealth;
        Instantiate(bloodDropsFX, transform.position, transform.rotation);

        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    private void MakeDead()
    {
        Destroy(gameObject);
        damageIndicator.color = new(255, 255, 255, 1);
    }
}
