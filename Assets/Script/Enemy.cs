using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemigo Vida
    [SerializeField] private float life;
    [SerializeField] private GameObject deathEffect;

    public void takeDamage(float damage)
    {
        Debug.Log("Vida: " + life);
        Debug.Log("Daño: " + damage);
        life -= damage;
        if (life <= 0)
        {
            Death();
        }
       
    }

    public void Death()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity); //Agregar la animacion cuando este creada
        Destroy(gameObject);
        Debug.Log("Ingresa a Nuerte");
    }
}
