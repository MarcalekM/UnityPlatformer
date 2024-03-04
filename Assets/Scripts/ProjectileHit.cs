using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float damage = 1f;

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
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            if (target.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = target.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.AddDamage(damage);
            }
        }
    }
}
