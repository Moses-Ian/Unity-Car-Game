using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            Debug.Log("Picked up package!");
            hasPackage = true;
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered to customer");
            hasPackage = false;
        }
        else if (collision.tag == "Customer")
        {
            Debug.Log("You need to pick up the package!");
        }
    }
}
