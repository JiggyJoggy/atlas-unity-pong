using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxInitAngle = 0.67f;
    public float speed;

    float scorePointLeft = 0;
    float scorePointRight = 0;

    // Starts and faces towards a random direction
    void Start()
    {
        speed += speed * 10;
        
        RandomizeBallMovementStartUp();
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

        if (other.CompareTag("Wall"))
        {
            float newYDir = rb.velocity.y * -1;
            Vector2 newVelocity = new Vector2(rb.velocity.x, newYDir);
            rb.velocity = newVelocity;
        }

        if (other.CompareTag("Goal"))
        {
            GameObject LeftGoal = GameObject.Find("LeftGoal");
            GameObject RightGoal = GameObject.Find("RightGoal");
            if (other.name == "LeftGoal")
            {
                scorePointRight++;
                GameObject RightScoreText = GameObject.Find("RightScore");
                RightScoreText.GetComponent<TextMeshProUGUI>().text = scorePointRight.ToString();
                if (scorePointRight == 11)
                {
                    RightGoal.GetComponent<Image>().color = Color.yellow;
                    RightGoal.GetComponentInChildren<TextMeshProUGUI>().text = "Winner!";
                    LeftGoal.GetComponent<Image>().color = Color.red;
                    LeftGoal.GetComponentInChildren<TextMeshProUGUI>().text = "Loser...";
                    GameOver();
                }
                else
                {
                    ResetBall();
                }
            }
            if (other.name == "RightGoal")
            {
                scorePointLeft++;
                GameObject LeftScoreText = GameObject.Find("LeftScore");
                LeftScoreText.GetComponent<TextMeshProUGUI>().text = scorePointLeft.ToString();
                if (scorePointLeft == 11)
                {
                    LeftGoal.GetComponent<Image>().color = Color.yellow;
                    LeftGoal.GetComponentInChildren<TextMeshProUGUI>().text = "Winner!";
                    RightGoal.GetComponent<Image>().color = Color.red;
                    RightGoal.GetComponentInChildren<TextMeshProUGUI>().text = "Loser...";
                    GameOver();
                }
                else
                {
                    ResetBall();
                }
            }
        }
    }

    // Restarts ball to starting pos
    public void ResetBall()
    {
        rb.position = new Vector3(960, 540, 0);
        rb.velocity = Vector3.zero;
        RandomizeBallMovementStartUp();
    }

    public void RandomizeBallMovementStartUp()
    {
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

    public void GameOver()
    {
        Debug.Log("We have a winner!");
    }
}
