using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef : NPC
{
    private int cookNum = 0;
    public Queue<Enums.Menu> WaitingQueue = new Queue<Enums.Menu>(8);
    public Queue<Enums.Menu> CookingQueue = new Queue<Enums.Menu>(8);
    public Queue<Enums.Menu> CompleteQueue = new Queue<Enums.Menu>(8);
    enum State
    {
        Cook, Break, Complete
    }
    public Enums.Menu menu;

    private State currentState = State.Break;

    private Coroutine cooking1;
    private Coroutine cooking2;
    public override void Interact()
    {
        
        GetOrder();
        if (currentState == State.Break)
        {
            Break();
        }

        if (currentState == State.Cook)
        {
            cookNum++;
        }

        if(currentState == State.Complete)
        {
            cookNum--;
        }
    }

    public override void _Update()
    {
        if(WaitingQueue.Count > 0 && CookingQueue.Count < 2)
        {
            CookingQueue.Enqueue(WaitingQueue.Dequeue());
        }
        if(CookingQueue.Count > 0)
        {
            if (cooking1 != null && cooking2 == null)
            {
                cooking2 = StartCoroutine(Cooking());
            }
            if (cooking1 == null)
            {
                cooking1 = StartCoroutine(Cooking());
            }
        }
    }

    private void GetOrder()
    {
        if (player.menuQueue.Count > 0)
        {
            WaitingQueue.Enqueue(player.menuQueue.Dequeue()); // 건네줌
        }
    }

    private void Break()
    {
        cookNum++;
        currentState = State.Cook;
    }
    IEnumerator Cooking()
    {
        Enums.Menu currentCook = CookingQueue.Dequeue();
        Debug.Log(currentCook + "조리 시작!");
        yield return new WaitForSeconds(4f);
        currentState = State.Complete;
        Debug.Log(currentCook + "조리 완료!");
        CompleteQueue.Enqueue(currentCook);
    }
}

