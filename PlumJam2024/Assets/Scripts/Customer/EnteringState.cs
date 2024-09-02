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
        //웨이 포인트 따라가기
        Move();
        //도착 시 상태 변경
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
            Animate();
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

    void Animate() {
        if(direction.x > direction.y) {
            customer.animator.SetBool("ishori", true);
            customer.animator.SetBool("isvert", false);
        }
        if(direction.x < direction.y) {
            customer.animator.SetBool("ishori", false);
            customer.animator.SetBool("isvert", true);
        }
        if(direction == Vector2.zero) {
            customer.animator.SetBool("ishori", false);
            customer.animator.SetBool("isvert", false);
        }
        customer.animator.SetFloat("hori", direction.y);
        customer.animator.SetFloat("vert", direction.x);
    }
}
