using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode Player1down;

    public KeyCode Player1up;
    
    public float thrust = 0.00001f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Player1down))
        {
            Transform t = GetComponent<Transform>();
            if (t.position.y > -11)
            {
                t.position += Vector3.down * 2;
            }
        }
        if (Input.GetKeyDown(Player1up))
        {
            Transform t = GetComponent<Transform>();
            if (t.position.y < 11)
            {
                t.position += Vector3.up * 2;
            }
        }
    }

    //This is code I adapted from a website. It didn't work out of the box, but it did give me ideas on how to proceed
    //It showed me how I could get a ball to speed up and recognize it's position relative to the paddle impact. 
    //The website is located here. Credit goes to Alessandro Valcepina. 
    //https://medium.com/@alessandrovalcepina/recreating-pong-with-unity-part-1-a53e8204c86
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Vector3 velocity = collision.rigidbody.velocity;
        if (contact.point.y > transform.position.y)
        {
            Vector3 direction = new Vector3(0, 1, 0);
            collision.rigidbody.AddForce(direction * thrust, ForceMode.Force);
            collision.rigidbody.AddForce(velocity / 10, ForceMode.VelocityChange);
        }
        else if (contact.point.y < transform.position.y)
        {
            Vector3 direction = new Vector3(0, -1, 0);
            collision.rigidbody.AddForce(direction * thrust, ForceMode.Force);
            collision.rigidbody.AddForce(velocity / 10, ForceMode.VelocityChange);
        }

    }
}
