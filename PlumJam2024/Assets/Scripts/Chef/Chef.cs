using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef : NPC
{
    public Queue<Enums.Menu> WaitingQueue = new Queue<Enums.Menu>(8);
    public Queue<Enums.Menu> CookingQueue = new Queue<Enums.Menu>(8);
    public Queue<Enums.Menu> CompleteQueue = new Queue<Enums.Menu>(8);

    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
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
        if (player.isServing) return;
        player.isServing = true;
        player.servingMenu = CompleteQueue.Dequeue();
        Debug.Log(player.servingMenu + "서빙 시작!");
        player.ShowServedFood(player.servingMenu, true);
        PickComplete();
    }

    private void Break()
    {
        currentState = State.Cook;
    }

    private void CookComplete(Enums.Menu currentMenu)
    {
        foreach (var item in player.completeFood)
        {
            if (item.activeSelf == false)
            {
                item.SetActive(true);
                SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Sprite chosenSprite = CurrentSpriteChoicer(currentMenu);
                    if (chosenSprite != null)
                    {
                        spriteRenderer.sprite = chosenSprite;
                        Debug.Log("스프라이트 변경 성공");
                    }
                    else
                    {
                        Debug.LogWarning("스프라이트 null");
                    }
                }
                else
                {
                    Debug.LogError("SpriteRenderer 컴포넌트X");
                }
                break;
            }
        }
    }

    private Sprite CurrentSpriteChoicer(Enums.Menu currentMenu)
    {
        
        Sprite currentSprite = null;
        if(currentMenu == Enums.Menu.cheesecake)
        {
            currentSprite = DataContainer.instance.cheesecake;
        }
        if (currentMenu == Enums.Menu.pancake)
        {
            currentSprite = DataContainer.instance.pancake;
        }
        if (currentMenu == Enums.Menu.chocolatepancake)
        {
            currentSprite = DataContainer.instance.chocolatepancake;
        }
        if (currentMenu == Enums.Menu.chocolatecake)
        {
            currentSprite = DataContainer.instance.chocolatecake;
        }
        if (currentMenu == Enums.Menu.cookiecheesecake)
        {
            currentSprite = DataContainer.instance.cookiecheesecake;
        }
        if (currentMenu == Enums.Menu.croissant)
        {
            currentSprite = DataContainer.instance.croissant;
        }
        if (currentMenu == Enums.Menu.tirimasu)
        {
            currentSprite = DataContainer.instance.tirimasu;
        }
        return currentSprite;
    }
    private void PickComplete()
    {
        foreach (var item in player.completeFood)
        {
            if (item.activeSelf == true)
            {
                item.SetActive(false);
                break;
            }
        }
    }
    private void CookingStart(Enums.Menu currentMenu)
    {
        foreach (var item in player.cookingFood)
        {
            if (item.activeSelf == false)
            {
                item.SetActive(true);
                SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    Sprite chosenSprite = CurrentSpriteChoicer(currentMenu);
                    if (chosenSprite != null)
                    {
                        spriteRenderer.sprite = chosenSprite;
                        Debug.Log("스프라이트 변경 성공");
                    }
                    else
                    {
                        Debug.LogWarning("스프라이트 null");
                    }
                }
                else
                {
                    Debug.LogError("SpriteRenderer 컴포넌트X");
                }
                break;
            }
        }
    }

    IEnumerator Cooking(int slot)
    {

        if (cookingCount >= 2)
        {
            yield break;
        }
        
        Slider slider = null;

        // 슬라이더 설정
        if (slot == 1)
        {
            slider = slider1.GetComponent<Slider>();
            slider1.gameObject.SetActive(true);
        }
        else if (slot == 2)
        {
            slider = slider2.GetComponent<Slider>();
            slider2.gameObject.SetActive(true);
        }
        if (slider == null)
        {
            Debug.LogError("Slider not found for slot: " + slot);
            yield break;
        }
        cookingCount++;
        Enums.Menu currentCook = CookingQueue.Dequeue();
        CookingStart(currentCook);
        Debug.Log(currentCook + " 조리 시작!");

        float duration = Enums.MenuTime[currentCook];
        slider.maxValue = duration;  // 슬라이더의 최대값을 설정

        float elapsedTime = 0f;
        slider.maxValue = duration;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            slider.value = elapsedTime;  // 슬라이더 값을 현재 경과 시간으로 설정
            yield return null;
        }

        currentState = State.Complete;
        Debug.Log(currentCook + " 조리 완료!");
        CompleteQueue.Enqueue(currentCook);

        // 슬라이더 초기화
        slider.value = 0;
        slider.gameObject.SetActive(false);

        if (slot == 1)
        {
            cooking1 = null;
            player.cookingFood[0].SetActive(false);
        }
        else if (slot == 2)
        {
            cooking2 = null;
            player.cookingFood[1].SetActive(false);
        }
        CookComplete(currentCook);
        cookingCount--;
    }

}

