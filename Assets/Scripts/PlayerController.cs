using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    public bool gameStarted = false;


    public static PlayerController Instance;
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }
          
        Instance = this;        
    }



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //desativa a fisica
        rb.simulated = false;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if(!gameStarted)
            {
                gameStarted = true;
                rb.simulated = true; //ativa a fisíca
            }
 
            rb.linearVelocity = Vector2.up * speed;
        }
    }

    private void Update()
    {
        if (rb.linearVelocity.y < -speed)

        {
            rb.linearVelocity = Vector2.down * speed;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver.instance.MetodoGameOver("Game Over");
            Destroy(gameObject);
        }
    }
}
