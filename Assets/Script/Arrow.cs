using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Fecha

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Vector2 direction;


    // Método público para establecer la dirección
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // Se normaliza para evitar que la velocidad cambie
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(direction* speed * Time.deltaTime, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
            
        }
        Debug.Log("Entro al tag Enemy");
    }
}
