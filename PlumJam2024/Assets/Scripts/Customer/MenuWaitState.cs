using UnityEngine;

public class MenuWaitState : CustomerState {
    public override void Exit() {
    }

    public override void _Update() {
        if(customer.isReceived) {
            stateMachine.ChangeState(stateMachine.Enjoying);
        }
        Debug.LogError("메뉴 대기시간 표시 미구현");
        customer.menuWatingTime -= Time.deltaTime;
        if(customer.menuWatingTime < 0) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }
}
