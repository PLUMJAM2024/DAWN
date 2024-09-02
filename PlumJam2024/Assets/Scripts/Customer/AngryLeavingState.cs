using UnityEngine;
using UnityEngine.iOS;

public class AngryLeavingState : CustomerState
{
    public override void Enter(CustomerStateMachine stateMachine) {
        base.Enter(stateMachine);
        //��θ� �Ųٷ� �Է�
        customer.init(customer.sit, true);
        ShowEmoji(Enums.Emoji.angryleaving);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void Exit() {

    }

    public override void _Update() {
        //���� ����Ʈ ���󰡱�
        Move();
        //���� �� ���� ����
        if (customer.waypoints.Count == 0) {
            Debug.LogError("ǳ�� ���� �̱���");
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
