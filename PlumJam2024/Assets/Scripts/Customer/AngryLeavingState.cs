using UnityEngine;

public class AngryLeavingState : CustomerState
{
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        //경로를 거꾸로 입력
        customer.init(customer.sit, true);
    }

    public override void Exit() {
    }

    public override void _Update() {
        //웨이 포인트 따라가기
        Move();
        //도착 시 상태 변경
        if (customer.waypoints.Count == 0) {
            Destroy(gameObject);
        }
    }

    void Move() {
        if (customer.sit != null) {
            customer.sit.isUsing = false;
        }
        if (customer.waypoints.Count != 0) {
            transform.position
                = Vector3.MoveTowards(
                    transform.position,
                    customer.waypoints[0].position,
                    customer.moveSpeed * Time.deltaTime);
            if ((transform.position - customer.waypoints[0].position).magnitude < 0.05f) {

                customer.waypoints.RemoveAt(0);
            }
        }
    }
}
