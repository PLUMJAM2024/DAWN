using UnityEngine;

public class LeavingState : CustomerState
{
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        //경로를 거꾸로 입력
        customer.init(customer.sit, true);
        HideEmoji();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void Exit() {
    }

    public override void _Update() {
        //웨이 포인트 따라가기
        Move();
        //도착 시 상태 변경
        if (customer.waypoints.Count == 0) {
            GameManager.instance.AddBalloon(true);
            Destroy(gameObject);
        }
    }

    void Move() {
        if (customer.sit != null) {
            customer.sit.isUsing = false;
        }
        if (customer.waypoints.Count != 0) {
            direction = (customer.waypoints[0].position - transform.position).normalized;
            transform.position
                = Vector3.MoveTowards(
                    transform.position,
                    customer.waypoints[0].position,
                    customer.moveSpeed * Time.deltaTime);
            if ((transform.position - customer.waypoints[0].position).magnitude < 0.05f) {

                customer.waypoints.RemoveAt(0);
            }
        }
        Animate();
    }
}
