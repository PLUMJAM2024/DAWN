using UnityEngine;

public class MenuWaitState : CustomerState {
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        ShowEmoji(Enums.Emoji.menuwaiting);
        direction = Vector2.zero;
        Animate();
    }

    public override void Exit() {
    }

    public override void _Update() {
        if(customer.isReceived) {
            stateMachine.ChangeState(stateMachine.Enjoying);
        }
        customer.menuWatingTime -= Time.deltaTime;
        if(customer.menuWatingTime < 0) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }
}
