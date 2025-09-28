using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Fecha

    [SerializeField] private float speed;
    [SerializeField] private float damage;

   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
            
        }
        Debug.Log("Entro al tag Enemy");
    }
}
