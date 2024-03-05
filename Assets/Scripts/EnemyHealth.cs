using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maximumHealth = 5f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maximumHealth;
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) MakeDead();
    }

    private void MakeDead()
    {
        Destroy(gameObject);
    }
}
