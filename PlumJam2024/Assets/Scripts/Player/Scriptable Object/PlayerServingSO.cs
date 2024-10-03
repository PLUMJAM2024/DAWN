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
            if (playerAction.hitCustomer.menu == playerController.servingMenu) // 주문한 메뉴가 일치
            {
                Debug.Log(playerController.servingMenu + " 잘 받았습니다잇!");
                playerAction.hitCustomer.isReceived = true;
                playerController.ShowServedFood(playerAction.hitCustomer.menu, false);
            }
            else if (playerAction.hitCustomer.menu != playerController.servingMenu) // 주문한 메뉴가 불일치
            {
                Debug.Log(playerController.servingMenu + " 저 이거 안시켰는데요?");
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
