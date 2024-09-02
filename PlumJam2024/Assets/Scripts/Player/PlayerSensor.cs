using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public float raycastDistance = 3f;
    RaycastHit2D hit;
    Ray2D ray;
    Rigidbody2D playerRigid;
    private Player player;

    
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        ray = new Ray2D(transform.position, transform.up);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * raycastDistance, Color.green);
        int layerMask = LayerMask.GetMask("Customer");
        hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance, layerMask);

        

        if (Input.GetKeyDown(KeyCode.E) && hit.collider != null)
        {
            Customer hitCustomer = hit.collider.GetComponent<Customer>();

            if (hitCustomer.isOrdered == false)
            {
                Debug.Log("Hit: " + hit.collider.name);
                hit.collider.GetComponent<Customer>().isOrdered = true;
                player.menuQueue.Enqueue(hitCustomer.menu);

                Debug.Log("Ordered Menu: " + player.menuQueue.Peek());
            }

            if (hitCustomer.isOrdered == true)
            {
                if (player.isServing && hitCustomer.menu == player.servingMenu)
                {
                    Debug.Log(player.servingMenu + "잘 받았습니다잇!");
                    hitCustomer.isReceived = true;
                    player.isServing = false;
                }
                else if(player.isServing && hitCustomer.menu != player.servingMenu)
                {
                    Debug.Log(player.servingMenu + "저 이거 안시켰는데요?");
                }
                else if(!player.isServing)
                {
                    Debug.Log(player.servingMenu + "아직 들고있는게 없어요");
                }
            }
        }
    }

    private void RotateSensor()
    {
        Vector3 velocity = playerRigid.velocity;

        if (velocity.x > 0f) // right 이동
        {

        }
        else if (velocity.x < 0f) // left 이동
        {
            transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
        else if (velocity.y > 0f) // back 이동
        {
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else if (velocity.y < 0f) // forward 이동
        {
            transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
    }
}
