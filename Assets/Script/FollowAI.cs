using System;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float followDistanceMin; // distancia m�nima para seguir
    [SerializeField] private float attackRange = 1.0f; // rango de ataque
    [SerializeField] private int attackDamage = 10;

    [Header("IA")]
    [SerializeField] private float attackCooldown = 1.0f;

    private float lastAttackTime = -Mathf.Infinity;
    private bool isFacingRight = true;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Follow();

        // Determina la direcci�n para voltear
        bool isPlayerRight = transform.position.x < player.position.x;
        Flip(isPlayerRight);
    }

    private void Follow()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > followDistanceMin && distanceToPlayer > attackRange)
        {
            // Mover hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        else
        {
            // Si ya est� cerca, detenerte y atacar si corresponde
            rb.linearVelocity = Vector2.zero;

            if (distanceToPlayer <= attackRange)
            {
                TryAttack();
            }
        }
    }

    private void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            Attack();
        }
    }

    private void Attack()
    {
        // Ataque "sin animaciones": aplica da�o si el jugador est� en rango
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            // Aplica da�o al jugador
            PlayerHealth ph = player.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(attackDamage);
            }

            // Opcional: aplicar knockback al jugador
            Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
            if (prb != null)
            {
                Vector2 knockDir = (player.position - transform.position).normalized;
                float knockbackForce = 200f; // ajusta seg�n tu juego
                prb.AddForce(knockDir * knockbackForce);
            }
        }
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }

    // Depuraci�n: mostrar rango de ataque en la escena
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
