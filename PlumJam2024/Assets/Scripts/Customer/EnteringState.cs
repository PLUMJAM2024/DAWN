using UnityEngine;

public class EnteringState : CustomerState {
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void Exit() {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public override void _Update() {
        //���� ����Ʈ ���󰡱�
        Move();
        //���� �� ���� ����
        if (customer.waypoints.Count == 0) {
            stateMachine.ChangeState(stateMachine.OrderWaiting);
        }
    }

    void Move() {
        if (customer.waypoints[customer.waypoints.Count - 1].GetComponent<Sit>() != null) {
            customer.waypoints[customer.waypoints.Count - 1].GetComponent<Sit>().isUsing = true;
        }

        if (customer.waypoints.Count != 0) {
            direction = (customer.waypoints[0].position - transform.position).normalized;
            transform.position 
                = Vector3.MoveTowards(
                    transform.position, 
                    customer.waypoints[0].position, 
                    customer.moveSpeed * Time.deltaTime);
            if ((transform.position - customer.waypoints[0].position).magnitude < 0.1f) {
                transform.position = customer.waypoints[0].position;
                customer.waypoints.RemoveAt(0);
            }
        }

        Animate();
    }

    
}
