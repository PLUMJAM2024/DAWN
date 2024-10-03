using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
[CreateAssetMenu(menuName = "playerServing")]
public class PlayerServingSO : PlayerStateSO
{
    public override void Execute(PlayerController playerController, PlayerAction playerAction)
    {
        if (playerAction.hitCustomer.isOrdered == true)
        {
            if (playerAction.hitCustomer.menu == playerController.servingMenu) // �ֹ��� �޴��� ��ġ
            {
                Debug.Log(playerController.servingMenu + " �� �޾ҽ��ϴ���!");
                playerAction.hitCustomer.isReceived = true;
                playerController.ShowServedFood(playerAction.hitCustomer.menu, false);
            }
            else if (playerAction.hitCustomer.menu != playerController.servingMenu) // �ֹ��� �޴��� ����ġ
            {
                Debug.Log(playerController.servingMenu + " �� �̰� �Ƚ��״µ���?");
            }
        }
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }
}
