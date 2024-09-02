using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public float raycastDistance = 3f;
    private RaycastHit2D hit;
    private Rigidbody2D playerRigid;
    private Player player;
    private Vector2 rayDirection;

    private PlayerAction action;

    void Start()
    {
        action = GetComponent<PlayerAction>();
        playerRigid = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        rayDirection = Vector2.down;
    }

    void Update()
    {
        RotateSensor();

        // 레이를 현재 방향으로 쏨
        hit = Physics2D.Raycast(transform.position, rayDirection, raycastDistance, LayerMask.GetMask("Customer"));
        Debug.DrawLine(transform.position, (Vector2)transform.position + rayDirection * raycastDistance, Color.green);

        if (Input.GetKeyDown(KeyCode.E) && hit.collider != null)
        {
            Customer hitCustomer = hit.collider.GetComponent<Customer>();

            if (hitCustomer.isOrdered == false)
            {
                Debug.Log("Hit: " + hit.collider.name);
                hitCustomer.isOrdered = true;
                player.menuQueue.Enqueue(hitCustomer.menu);

                Debug.Log("Ordered Menu: " + player.menuQueue.Peek());
            }

            if (hitCustomer.isOrdered == true)
            {
                if (player.isServing && hitCustomer.menu == player.servingMenu)
                {
                    Debug.Log(player.servingMenu + " 잘 받았습니다잇!");
                    hitCustomer.isReceived = true;
                    player.isServing = false;
                    player.ShowServedFood(hitCustomer.menu, false);
                }
                else if (player.isServing && hitCustomer.menu != player.servingMenu)
                {
                    Debug.Log(player.servingMenu + " 저 이거 안시켰는데요?");
                }
                else if (!player.isServing)
                {
                    Debug.Log(player.servingMenu + " 아직 들고있는게 없어요");
                }
            }
        }
    }

    private void RotateSensor()
    {
        Vector2 velocity = playerRigid.velocity;

        if (action.h > 0f)
        {
            rayDirection = Vector2.right;
        }
        else if (action.h < 0f)
        {
            rayDirection = Vector2.left;
        }
        else if (action.v > 0f)
        {
            rayDirection = Vector2.up;
        }
        else if (action.v < 0f)
        {
            rayDirection = Vector2.down;
        }
    }
}
