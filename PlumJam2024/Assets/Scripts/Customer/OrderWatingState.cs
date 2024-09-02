using UnityEngine;

public class OrderWatingState : CustomerState {
    public override void Exit() {
    }

    public override void _Update() {
        if(customer.isOrdered) {
            stateMachine.ChangeState(stateMachine.MenuWating);
        }
        //Debug.LogError("���ϴ� �޴� ǥ�� �̱���");
        customer.orderWatingTime -= Time.deltaTime;
        if(customer.orderWatingTime < 0 ) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }
}
