using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float speed;

    void Start()
    {
        speed += speed * 100;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if (transform.localPosition.y >= 460)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 455);
            }
        }
        if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (transform.localPosition.y <= -460)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, -455);
            }
        }
    }
}
