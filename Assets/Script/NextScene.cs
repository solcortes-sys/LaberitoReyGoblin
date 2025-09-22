using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Player"))
      //  if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Room2");
            Debug.Log("entro para cargar la nueva escena");
        }
        GameObject oEntrante = collision.gameObject;
        Debug.Log("Este es un mensaje de la colision en la puerta verdadera ");
        Debug.Log(oEntrante.name);
    }
}
