using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force;
    public void Start()
    {
        if(transform.position.x > 0){
            GetComponent<Rigidbody>().AddForce(transform.right * -force);
        }
        if(transform.position.x < 0){
            GetComponent<Rigidbody>().AddForce(transform.right * force);
        }

    }
}
