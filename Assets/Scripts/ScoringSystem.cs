using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public static int p1Score = 0;
    public static int p2Score = 0;
    public GameObject ballPrefab;
    public Transform spawnTransform;
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ball"){
            ContactPoint contact = collision.GetContact(0);
            if(contact.point.x > transform.position.x){
                p2Score = p2Score + 1;
                Debug.Log("P2 scored! Current score is " + p1Score + " to " + p2Score);
                Destroy(collision.gameObject);
                if(p2Score == 11){ 
                    Debug.Log("Game over! P2 wins!");
                    Debug.Log("Resetting the score....");
                    p1Score = 0;
                    p2Score = 0;
                }
                Vector3 spawnPosition = spawnTransform.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            }
            if(contact.point.x < transform.position.x){
                p1Score = p1Score + 1;
                Debug.Log("P1 scored! Current score is " + p1Score + " to " + p2Score);
                Destroy(collision.gameObject);
                if(p1Score == 11){
                    Debug.Log("Game over! P1 wins!");
                    Debug.Log("Resetting the score....");
                    p1Score = 0;
                    p2Score = 0;
                }
                Vector3 spawnPosition = spawnTransform.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
