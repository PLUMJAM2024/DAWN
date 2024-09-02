using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private enum State{
        isOrderReceived, WaitingForOrder
    }
    private State currentState = State.WaitingForOrder;
    void Start()
    {
        
    }

    private void Update()
    {
        
        switch (currentState) // 현재 상태가
        {
            case State.isOrderReceived: // 주문 받았으면
                //DoServing();
                break;

            case State.WaitingForOrder: // 주문 기다리면
                //DoFree();
                break;
        }
    }
}
