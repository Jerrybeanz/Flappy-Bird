using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public GameObject logicManager;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Vector2 screenBounds;
    private float birdHeight;
    private AudioSource audioSource;
    public GameObject body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = logicManager.GetComponent<LogicScript>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        birdHeight = body.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null && keyboard.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            if (myRigidBody != null)
            {
                myRigidBody.linearVelocity = Vector2.up * flapStrength;
            }
        }
        // Clamp bird's position to stay within screen bounds
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y + birdHeight, screenBounds.y - birdHeight);
        transform.position = new Vector2(transform.position.x, clampedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        audioSource.Play();
    }
}
