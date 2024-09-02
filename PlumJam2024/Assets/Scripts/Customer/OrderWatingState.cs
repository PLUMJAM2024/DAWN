using UnityEngine;

public class OrderWatingState : CustomerState {
    public override void Exit() {
    }

    public override void _Update() {
        if(customer.isOrdered) {
            stateMachine.ChangeState(stateMachine.MenuWating);
        }
        //Debug.LogError("원하는 메뉴 표시 미구현");
        customer.orderWatingTime -= Time.deltaTime;
        if(customer.orderWatingTime < 0 ) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }
}
