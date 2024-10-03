using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[Serializable]
public class PlayerStateMachine
{
    public PlayerStateSO CurrentState;
    public PlayerServingSO servingState;
    public PlayerWaitingSO waitingState;
    public void Initialize()
    {
        CurrentState = waitingState;
        Debug.Log("플레이어 상태: " + CurrentState.name);
        CurrentState.Enter();
    }
    public void TransitionTo(PlayerStateSO nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        Debug.Log("플레이어 상태: " + CurrentState.name);
        nextState.Enter();
    }
    public void Update(PlayerController playerController, PlayerAction playerAction)
    {
        CurrentState?.Execute(playerController, playerAction);
    }
}