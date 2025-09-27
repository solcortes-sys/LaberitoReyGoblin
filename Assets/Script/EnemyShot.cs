using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // Disparo del enemigo

    public Transform manageShot;            //Controlador de Disparos
    public float distanceLine;               //Distancia en Linea
    public LayerMask LayerPlayer;           //Capa del jugador
    public bool RangePlayer;                //jugador en rango

    private void Update()
    {
        RangePlayer = Physics2D.Raycast(manageShot.position, transform.right, distanceLine, LayerPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(manageShot.position, manageShot.position + transform.right * distanceLine);
    }
}
