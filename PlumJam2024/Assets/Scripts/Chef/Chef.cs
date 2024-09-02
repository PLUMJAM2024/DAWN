using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef : NPC
{
    private int cookNum = 0;
    public Queue<Enums.Menu> menuQueue = new Queue<Enums.Menu>(8);
    enum State
    {
        Cook, Break, Complete
    }
    public Enums.Menu menu;

    private State currentState = State.Break;
    public override void Interact()
    {
        if(currentState == State.Break)
        {
            cookNum++;
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
        if(menuQueue.Count > 0)
        {

        }
    }

    private void GetOrder()
    {
        menuQueue.Enqueue(player.menuQueue.Dequeue()); // °Ç³×ÁÜ
    }

    private void Break()
    {
        cookNum++;
        currentState = State.Cook;
    }
    IEnumerator Cooking()
    {
        yield return new WaitForSeconds(4f);
    }
}

