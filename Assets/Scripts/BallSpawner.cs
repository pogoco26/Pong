using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = spawnTransform.position;
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
