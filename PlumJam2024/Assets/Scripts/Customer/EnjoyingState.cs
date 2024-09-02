using UnityEngine;

public class EnjoyingState : CustomerState {
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        GetComponent<BoxCollider2D>().enabled = false;
        customer.enjoyingTime += Random.Range(0, 2);
    }

    public override void Exit() {
    }

    public override void _Update() {
        customer.enjoyingTime -= Time.deltaTime;
        if (customer.enjoyingTime < 0) {
            stateMachine.ChangeState(stateMachine.Leaving);
        }
    }
}
