using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    // Starts and faces towards a random direction
    void Start()
    {
        float num = Random.Range(1, 10);

        if (num >= 5)
        {
            rb.AddForce(Vector2.right * speed);
            rb.AddForce(Vector2.up * speed);
        }
        else
        {
            rb.AddForce(Vector2.left * speed);
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            Debug.Log("Ball hit paddle"); // Will replace with AddForce
        }
    }

    // Restarts ball to starting pos
    public void Restart()
    {
        rb.position = new Vector3(960, 540, 0);
    }
}
