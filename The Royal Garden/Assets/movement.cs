using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    private float pixel = 1;
    private bool isColliding;
    //private CharacterController controller;

    private void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = 0;
        float y = 0;
        if (Input.GetKey("left"))
        {
            x = -1;
        }
        if (Input.GetKey("right"))
        {
            x = 1;
        }
        if (Input.GetKey("up"))
        {
            y = 1;
        }
        if (Input.GetKey("down"))
        {
            y = -1;
        }
        if (isColliding) {
            x = 0;
            y = 0;
        }
        Vector2 move = new Vector2(x * pixel, y * pixel);
        //controller.Move(move * Time.deltaTime * playerSpeed);
        transform.Translate(move * Time.deltaTime * playerSpeed);
    }
    void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        print("collision");
    }
}
