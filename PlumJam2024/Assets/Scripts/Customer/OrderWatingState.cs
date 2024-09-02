using UnityEngine;

public class OrderWatingState : CustomerState {
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);

        ShowEmoji(Enums.Emoji.orderwaiting);
    }

    public override void Exit() {
    }

    public override void _Update() {
        if(customer.isOrdered) {
            stateMachine.ChangeState(stateMachine.MenuWaiting);
        }
        customer.orderWatingTime -= Time.deltaTime;
        if(customer.orderWatingTime < 0 ) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }

    
}
