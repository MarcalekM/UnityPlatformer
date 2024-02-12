using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maximumHealth = 100;
    
    private float currentHealth;

    private void Start()
    {
        currentHealth = maximumHealth;
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0) MainDeath();
    }

    private void MainDeath()
    {
        Destroy(gameObject);
    }
}
