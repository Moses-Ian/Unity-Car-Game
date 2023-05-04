using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] static float baseMoveSpeed = 20f;
    [SerializeField] float slowSpeed = 17f;
    [SerializeField] float boostSpeed = 23f;
    [SerializeField] float moveSpeed = baseMoveSpeed;

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
