using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodDrops;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private AudioClip playerGrunt;
    private float currentHealt;
    private AudioSource audioSource;

    private void Start()
    {
        currentHealt = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        currentHealt -= damage;
        healthBar.value = currentHealt;
        audioSource.PlayOneShot(playerGrunt);
        Instantiate(bloodDrops, transform.position, transform.rotation);

        if (currentHealt <= 0)
        {
            MakeDead();
        }
    }

    private void MakeDead()
    {
        Destroy(gameObject);
    }
}
