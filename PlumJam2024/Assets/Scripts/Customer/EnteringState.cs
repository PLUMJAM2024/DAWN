using UnityEngine;

public class EnteringState : CustomerState {
    public override void Exit() {
        
    }

    public override void _Update() {
        //���� ����Ʈ ���󰡱�
        Move();
        //���� �� ���� ����
        //Debug.LogError($"���� �� ���� ���� �̱���");
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
