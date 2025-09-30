using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Fecha

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject Player;
    

   
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

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
