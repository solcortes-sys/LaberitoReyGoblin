using UnityEngine;

public class ShotPlayer : MonoBehaviour  
{
    // Disparos del Jugador

    [SerializeField] private Transform controllerShots;
    [SerializeField] private GameObject arrow;
    
   
    public PlayerMovement playerMovement; 

   
    // Variable para almacenar la última dirección válida (LastX, LastY)
    private Vector2 lastDirection;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Dispara");
        }
    }

    private void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, controllerShots.position, Quaternion.identity);
        // Obtener el componente Arrow y establecer su dirección
        Arrow arrowScript = newArrow.GetComponent<Arrow>();
        if (arrowScript != null)
        {
            // Pasar la dirección desde el script de movimiento del jugador
            if (playerMovement != null && playerMovement.lastDirection != Vector2.zero)
            {
                arrowScript.SetDirection(playerMovement.lastDirection);
            }
            else
            {
                // Dirección por defecto si el jugador no se ha movido
                arrowScript.SetDirection(Vector2.right);
            }
        }
    }
}
