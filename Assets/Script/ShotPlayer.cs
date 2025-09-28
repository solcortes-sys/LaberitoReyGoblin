using UnityEngine;

public class ShotPlayer : MonoBehaviour  
{
    // Disparos del Jugador

    [SerializeField] private Transform controllerShots;
    [SerializeField] private GameObject arrow;

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
        Instantiate(arrow, controllerShots.position, controllerShots.rotation);
    }
}
