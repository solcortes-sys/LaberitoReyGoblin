using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Jugador recibió " + amount + " daño. Salud: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Lógica de muerte del jugador (desativar controles, reproducir animación, etc.)
        Debug.Log("Jugador muerto");
        // Ejemplo:
        // GetComponent<PlayerController>().enabled = false;
        // gameObject.SetActive(false);
    }
}