using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerSpeed = 300f;
    static float baseMoveSpeed = 20f;
    float slowSpeed = 12f;
    float boostSpeed = 28f;
    float moveSpeed = baseMoveSpeed;

    void Start()
    {

    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Speed Up")
            moveSpeed = boostSpeed;
        else if (collision.tag == "Slow Down")
            moveSpeed = slowSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = baseMoveSpeed;
    }
}
