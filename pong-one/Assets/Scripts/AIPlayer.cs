using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Paddle>();
        gameObject.GetComponent<Player>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {

    }
}
