using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float speed,xBound;
  

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        xBound = Input.acceleration.x * speed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.7f, 2.7f), transform.position.y);
    }

    void FixedUpdate()
    {
        rgbd.velocity = new Vector2(xBound, 0f);
    }
}
