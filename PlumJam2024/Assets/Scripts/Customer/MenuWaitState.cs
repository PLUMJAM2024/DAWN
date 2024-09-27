using UnityEngine;

public class MenuWaitState : CustomerState {
    private float maxTime;
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        ShowEmoji(DataManager.instance.emojis["menuwaiting"]);
        maxTime = customer.menuWaitingTime;
        direction = Vector2.zero;
        Animate();
    }

    public override void Exit() {
    }

    public override void _Update() {
        if (customer.isReceived) {
            stateMachine.ChangeState(stateMachine.Enjoying);
        }
        customer.menuWaitingTime -= Time.deltaTime;
        customer.timer.fillAmount = customer.menuWaitingTime / maxTime;
        if (customer.menuWaitingTime < 0) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }
}
