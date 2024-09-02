using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float raycastDistance = 3f;
    RaycastHit2D hit;
    Ray2D ray;
    Rigidbody2D playerRigid;
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ray = new Ray2D(transform.position, transform.up);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * raycastDistance, Color.green);
        int layerMask = LayerMask.GetMask("Customer");
        hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance, layerMask);

        if (Input.GetKeyDown(KeyCode.E) && hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            hit.collider.GetComponent<Customer>().isOrdered = true;
        }
    }
}
