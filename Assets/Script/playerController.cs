using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed;
    private void OnMove(InputValue InputValue)
    {
        Vector2 move = InputValue.Get<Vector2>();
        _rb.linearVelocity = move * _speed;

        Debug.Log("se ejecuto el Metodo Move");
    }
    private void OnAttack()
    {
        Debug.Log("se ejecuto el Metodo Attack");
    }
}
