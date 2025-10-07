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
        Debug.Log("Jugador recibi� " + amount + " da�o. Salud: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // L�gica de muerte del jugador (desativar controles, reproducir animaci�n, etc.)
        Debug.Log("Jugador muerto");
        // Ejemplo:
        // GetComponent<PlayerController>().enabled = false;
        // gameObject.SetActive(false);
    }
}