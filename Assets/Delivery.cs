using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    Color32 hasPackageColor = new Color32(0, 255, 255, 255);
    Color32 noPackageColor = new Color32(255, 255, 255, 255);
    SpriteRenderer spriteRenderer;

    bool hasPackage = false;
    [SerializeField] float packageDestroyDelay = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked up package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, packageDestroyDelay);
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered to customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        else if (collision.tag == "Customer")
        {
            Debug.Log("You need to pick up the package!");
        }
    }
}
