using UnityEngine;
using UnityEngine.SceneManagement;
public class PreviousScena : MonoBehaviour
{

   

        private void OnTriggerEnter2D(Collider2D collision)
        {

            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int targetIndex = currentIndex - 1;

            int totalScenes = 4;
            if (targetIndex < 0) targetIndex = totalScenes - 1; // wrap-around


            SceneManager.LoadScene(targetIndex);
            Debug.Log("entro para cargar la nueva escena");
            
            GameObject oEntrante = collision.gameObject;
            Debug.Log("Este es un mensaje de la colision en la puerta verdadera ");
            Debug.Log(oEntrante.name);


        }
}
