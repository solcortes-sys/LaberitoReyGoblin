using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private Camera camara; // Cámara a re-hijar, si no está asignada usar GameObject.FindObjectOfType<Camera>()


    private void OnTriggerEnter2D(Collider2D collision)

    {
       // if (collision.CompareTag("FalseDoor"))
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 10f;
               
                rb.transform.SetParent(camara.transform);
            }
           
        }
       
       
        Debug.Log("Entro al FALL por Trigeer");
        Debug.Log(collision.name);
    }
    
}

