using UnityEngine;

public class MissleHit : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private GameObject explosionEcffect;

    private ProjectileController controller;

    private void Awake()
    {
        controller = GetComponentInParent<ProjectileController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Hitable"))
        {
            controller.Stop();
            Instantiate(explosionEcffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
