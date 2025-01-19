using UnityEngine;

public class Seaweed : MonoBehaviour
{
    
    public float speed = 5f;

    private float edge;

    private void Start()
    {
        edge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; 
        
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < edge)
        {
            Destroy(gameObject);
        }
    }



}
