using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef : NPC
{
    public Queue<Enums.Menu> WaitingQueue = new Queue<Enums.Menu>(8);
    public Queue<Enums.Menu> CookingQueue = new Queue<Enums.Menu>(8);
    public Queue<Enums.Menu> CompleteQueue = new Queue<Enums.Menu>(8);
    enum State
    {
        Cook, Break, Complete
    }
    public Enums.Menu menu;

    private State currentState = State.Break;

    int cookingCount = 0;


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
        }

        if(currentState == State.Complete)
        {
            GiveCook();
        }
    }

    public override void _Update()
    {
        if (WaitingQueue.Count > 0 && CookingQueue.Count < 2)
        {
            CookingQueue.Enqueue(WaitingQueue.Dequeue());
        }
        if (CookingQueue.Count > 0)
        {
            if (cooking1 == null)
            {
                cooking1 = StartCoroutine(Cooking(1));
            }
            else if (cooking2 == null)
            {
                cooking2 = StartCoroutine(Cooking(2));
            }
        }
    }

    private void GetOrder()
    {
        while (player.menuQueue.Count > 0)
        {
            WaitingQueue.Enqueue(player.menuQueue.Dequeue());
        }
    }

    private void GiveCook()
    {
        if(CompleteQueue.Count == 0) { return; }
        player.isServing = true;
        player.servingMenu = CompleteQueue.Dequeue();
        Debug.Log(player.servingMenu + "서빙 시작!");
        player.ShowServedFood(player.servingMenu, true);
    }

    private void Break()
    {
        currentState = State.Cook;
    }
    IEnumerator Cooking(int slot)
    {
        if (cookingCount >= 2)
        {
            yield break;
        }
        cookingCount++;
        Enums.Menu currentCook = CookingQueue.Dequeue();
        Debug.Log(currentCook + " 조리 시작!");
        yield return new WaitForSeconds(Enums.MenuTime[currentCook]);
        currentState = State.Complete;
        Debug.Log(currentCook + " 조리 완료!");
        CompleteQueue.Enqueue(currentCook);

        if (slot == 1)
        {
            cooking1 = null;
        }
        else if (slot == 2)
        {
            cooking2 = null;
        }
        cookingCount--;
    }
}

