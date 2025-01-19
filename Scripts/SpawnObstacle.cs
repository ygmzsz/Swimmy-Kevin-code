using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    
void Start()
{
    OnEnable();
}
    public void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawnRate, spawnRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }

    public void spawn()
    {
        GameObject seaweed = Instantiate(prefab, transform.position, Quaternion.identity);
        seaweed.transform.position += Vector3.up * UnityEngine.Random.Range(minHeight, maxHeight);
    }
}
