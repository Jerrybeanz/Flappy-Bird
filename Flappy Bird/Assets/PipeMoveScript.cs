using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 20;
    public BirdScript birdScript;
    public Vector2 screenBounds;
    private float pipeWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdScript = GameObject.Find("Bird").GetComponent<BirdScript>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        pipeWidth = GameObject.Find("Top Pipe").GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x - pipeWidth)
        {
            Debug.Log("Pipe Destroyed");
            Destroy(gameObject);
        }
        if (birdScript.birdIsAlive)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
