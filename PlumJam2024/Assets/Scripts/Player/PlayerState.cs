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
        
        switch (currentState) // ���� ���°�
        {
            case State.isOrderReceived: // �ֹ� �޾�����
                //DoServing();
                break;

            case State.WaitingForOrder: // �ֹ� ��ٸ���
                //DoFree();
                break;
        }
    }
}
