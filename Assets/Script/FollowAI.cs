using UnityEngine;

public class FollowAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform player;
    [SerializeField] private float speed; 
    private bool isFacingRight = true;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }
    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight)|| (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 Scale = transform.localScale;
            Scale.x = -1;
            transform.localScale = Scale;
        }
       
    }
}
