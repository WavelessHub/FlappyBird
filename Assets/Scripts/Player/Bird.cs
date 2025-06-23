using UnityEngine;

public class Bird : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;

    private GameManager gameManager;

    [SerializeField] private float jumpForce = 15f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {
        if (!gameManager.HasGameStarted()) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        AudioManager.instance.PlaySFX(2);

        rb.linearVelocityY = jumpForce;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "Obstacle")
        {
            AudioManager.instance.PlaySFX(0);

            GameManager.instance.GameOver();
        }

        if (layerName == "Score")
        {
            AudioManager.instance.PlaySFX(1);

            GameManager.instance.IncrementScore();
        }
    }
}
