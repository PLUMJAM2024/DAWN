using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Queue<MenuSO> menuQueue = new Queue<MenuSO>(8);
    public Queue<GameObject> readyQueue = new Queue<GameObject>(8);
    public GameObject[] completeFood = new GameObject[5];
    public GameObject[] cookingFood = new GameObject[2];
    public MenuSO servingMenu;
    private PlayerAction playerAction;

    public PlayerStateMachine playerStateMachine;

    public bool isServing { get; private set; }

    [SerializeField] private GameObject servingObject;

    public void StartServing(MenuSO servingMenu)
    {
        this.servingMenu = servingMenu;
        ShowServedFood(this.servingMenu, true);
        isServing = true;
    }

    public void EndServing()
    {
        this.servingMenu = null;
        ShowServedFood(this.servingMenu, true);
        isServing = false;
    }

    public void ShowServedFood(MenuSO menu, bool isShow)
    {
        if (isShow)
        {
            playerStateMachine.TransitionTo(playerStateMachine.servingState);
            servingObject.GetComponent<SpriteRenderer>().sprite = servingMenu.GetSprite();
        }
        else
        {
            playerStateMachine.TransitionTo(playerStateMachine.waitingState);
            servingObject.GetComponent<SpriteRenderer>().sprite = null;
            servingMenu = null;
        }
    }

    private void Start()
    {
        playerAction = GetComponent<PlayerAction>();
        playerStateMachine.Initialize();
        isServing = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        { // ¹ö¸®±â
            ThrowAway();
        }

        if (Input.GetKeyDown(KeyCode.E) && playerAction.hit.collider != null)
        {
            playerAction.hitCustomer = playerAction.hit.collider.GetComponent<Customer>();

            playerStateMachine.Update(this, playerAction);
        }
    }

    private void ThrowAway()
    {
        ShowServedFood(servingMenu, false);
        servingMenu = null;
        isServing = false;
    }
}