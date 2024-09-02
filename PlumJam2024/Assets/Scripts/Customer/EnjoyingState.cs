using UnityEngine;

public class EnjoyingState : CustomerState {
    private float maxtime;
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        GetComponent<BoxCollider2D>().enabled = false;
        customer.enjoyingTime += Random.Range(0, 2);
        maxtime = customer.enjoyingTime;
        ShowEmoji(Enums.Emoji.enjoying);
        direction = Vector2.zero;
        Animate();
    }

    public override void Exit() {
    }

    public override void _Update() {
        customer.enjoyingTime -= Time.deltaTime;
        customer.timer.fillAmount = customer.enjoyingTime / maxtime;
        if (customer.enjoyingTime < 0) {
            stateMachine.ChangeState(stateMachine.Leaving);
        }
    }
}
