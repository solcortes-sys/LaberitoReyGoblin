using UnityEngine;

public class LifeTime : MonoBehaviour
{
    // Tiempo de vida
    [SerializeField] private float liveTime;
    void Start()
    {
        Destroy(gameObject, liveTime);
    }

}  
