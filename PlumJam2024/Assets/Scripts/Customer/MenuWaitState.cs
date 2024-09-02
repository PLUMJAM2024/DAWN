using UnityEngine;

public class MenuWaitState : CustomerState {
    public override void Exit() {
    }

    public override void _Update() {
        if(customer.isReceived) {
            stateMachine.ChangeState(stateMachine.Enjoying);
        }
        Debug.LogError("�޴� ���ð� ǥ�� �̱���");
        customer.menuWatingTime -= Time.deltaTime;
        if(customer.menuWatingTime < 0) {
            stateMachine.ChangeState(stateMachine.AngryLeaving);
        }
    }
}
