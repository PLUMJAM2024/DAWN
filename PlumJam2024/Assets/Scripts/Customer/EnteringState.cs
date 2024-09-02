using UnityEngine;

public class EnteringState : CustomerState {
    public override void Exit() {
        
    }

    public override void _Update() {
        //웨이 포인트 따라가기
        Move();
        //도착 시 상태 변경
        //Debug.LogError($"도착 시 상태 변경 미구현");
        if (customer.waypoints.Count == 0) {
            stateMachine.ChangeState(stateMachine.OrderWaiting);
        }
    }

    void Move() {
        if(customer.waypoints.Count != 0) {
            transform.position 
                = Vector3.MoveTowards(
                    transform.position, 
                    customer.waypoints[0].position, 
                    customer.moveSpeed * Time.deltaTime);
            if ((transform.position - customer.waypoints[0].position).magnitude < 0.1f) {
                customer.waypoints.RemoveAt(0);
            }
        }
    }
}
