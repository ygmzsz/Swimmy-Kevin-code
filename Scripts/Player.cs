using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer change;
    public Sprite[] sprites;
    private int index; 
    private Vector3 direction;
    public float gravity = -9.81f;
    public float swim = 5f;

    private void Awake()
    {
        change = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(spriteAnimation), 0.15f, 0.15f);
    }

    public void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * swim;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        
    }
    

    private void spriteAnimation()
   {
        if (sprites.Length == 0) 
        {
            return;
        }

        index++;
        if (index >= sprites.Length)
        {
            index = 0;
        }

        change.sprite = sprites[index];
    }

  private bool hasScored = false;

private void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.tag == "Obstacle")
    {
        FindObjectOfType<GameManager>().GameOver();
    }
    else if (other.gameObject.tag == "Scoring" && !hasScored)
    {
        hasScored = true;
        FindObjectOfType<GameManager>().Scoring();
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.gameObject.tag == "Scoring")
    {
        hasScored = false; 
    }
}
}
