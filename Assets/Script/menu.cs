using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private float speed = 20f;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // obtiene el componente Rigidbody2D del objeto al que está adjuntado este script
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");// obtiene la entrada horizontal (A/D o flechas izquierda/derecha)
        float moveY = Input.GetAxisRaw("Vertical");// obtiene la entrada vertical (W/S o flechas arriba/abajo)
        moveInput = new Vector2(moveX, moveY);// crea un vector2 con la entrada de movimiento
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.deltaTime);// mueve el Rigidbody2D a la nueva posición calculada
    }
    
    private void OnTriggerStay2D(Collider2D collision)// se llama cuando el collider del objeto con el que colisiona permanece en contacto
    {
        if ((Input.GetKeyDown(KeyCode.H)) && (collision.gameObject.layer == LayerMask.NameToLayer("start"))) // si se presiona la tecla espacio y el objeto con el que colisiona tiene la etiqueta "start"
            {
            SceneManager.LoadScene("Room1");// carga la escena llamada "Room1"
        }   


        if ((collision.gameObject.layer == LayerMask.NameToLayer("quit")) && (Input.GetKeyDown(KeyCode.H))) // si el objeto con el que colisiona tiene la etiqueta "quit"
        {
            Debug.Log("salir"); //***************   borrar esta linea   *********** 
            Application.Quit(); // cierra la aplicacion
        }

       
    }
}
