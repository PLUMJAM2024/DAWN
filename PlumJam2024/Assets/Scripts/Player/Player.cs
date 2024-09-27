using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Queue<MenuSO> menuQueue = new Queue<MenuSO>(8);
    public Queue<GameObject> readyQueue = new Queue<GameObject>(8);
    public MenuSO servingMenu;
    public bool isServing = false;

    [SerializeField] GameObject servingObject;

    public GameObject[] completeFood = new GameObject[5];
    public GameObject[] cookingFood = new GameObject[2];
    public void ShowServedFood(MenuSO menu, bool isShow)
    {
        if (isShow)
        {
            servingObject.GetComponent<SpriteRenderer>().sprite = servingMenu.GetSprite();
        }
        else
        {
            servingObject.GetComponent<SpriteRenderer>().sprite = null;
            servingMenu = null;
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) { // ¹ö¸®±â
            ShowServedFood(servingMenu, false);
            servingMenu = null;
            isServing = false;
        }
    }
}