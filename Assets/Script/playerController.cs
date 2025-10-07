using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed;
    [SerializeField] private Transform attackController;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float damage;
    private void OnMove(InputValue InputValue)
    {
        Vector2 move = InputValue.Get<Vector2>();
        _rb.linearVelocity = move * _speed;

        Debug.Log("se ejecuto el Metodo Move");
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            OnAttack();
        }
    }
    private void OnAttack()
    {
        Collider2D[] touchObject = Physics2D.OverlapCircleAll(attackController.position, radioAtaque);
        foreach (Collider2D objeto in touchObject)
        {
            Debug.Log(objeto.name);
            if(objeto.TryGetComponent(out Enemy enemyLife))
            {
                enemyLife.TakeDamage(damage);
            }
        }
        Debug.Log("se ejecuto el Metodo Attack");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackController.position, radioAtaque);
    }
}
