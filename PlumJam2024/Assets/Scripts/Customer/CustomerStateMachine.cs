using UnityEngine;

public class CustomerStateMachine : MonoBehaviour {
    public CustomerState Entering;
    public CustomerState OrderWaiting;
    public CustomerState MenuWaiting;
    public CustomerState Enjoying;
    public CustomerState Leaving;
    public CustomerState AngryLeaving;

    public CustomerState CurrentState;

    private void Start() {
        Entering = gameObject.AddComponent<EnteringState>();
        OrderWaiting = gameObject.AddComponent<OrderWatingState>();
        MenuWaiting = gameObject.AddComponent<MenuWaitState>();
        Enjoying = gameObject.AddComponent<EnjoyingState>();
        Leaving = gameObject.AddComponent<LeavingState>();
        AngryLeaving = gameObject.AddComponent<AngryLeavingState>();

        ChangeState(Entering);
    }

    public void ChangeState(CustomerState newState) {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter(this);
    }

}
