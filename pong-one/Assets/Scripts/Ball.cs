using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxInitAngle = 0.67f;
    public float speed;

    // Starts and faces towards a random direction
    void Start()
    {
        speed += speed * 10;
        float num = Random.Range(1, 10);

        if (num >= 5)
        {
            Vector2 dir = Vector2.left * speed;
            dir.y = Random.Range(-maxInitAngle, maxInitAngle) * 100;
            rb.velocity = dir;
        }
        else
        {
            Vector2 dir = Vector2.right * speed;
            dir.y = Random.Range(-maxInitAngle, maxInitAngle) * 100;
            rb.velocity = dir;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            if (rb.position.y < other.transform.position.y)
            {
                rb.AddForce(Vector2.up * 5000);
            }
            if (rb.position.y > other.transform.position.y)
            {
                rb.AddForce(Vector2.down * 5000);
            }
            rb.velocity *= -1;
            rb.rotation *= -1;
        }
    }

    // Restarts ball to starting pos
    public void ResetBall()
    {
        rb.position = new Vector3(960, 540, 0);
        rb.velocity = Vector3.zero;
    }
}
