using UnityEngine;

public abstract class CustomerState : MonoBehaviour
{
    protected CustomerStateMachine stateMachine;
    protected Customer customer;
    public virtual void Enter(CustomerStateMachine stateMachine) {
        Debug.Log($"State : {this.GetType().Name}");
        this.stateMachine = stateMachine;
        customer = GetComponent<Customer>();
    }

    public abstract void _Update();

    public abstract void Exit();
}
