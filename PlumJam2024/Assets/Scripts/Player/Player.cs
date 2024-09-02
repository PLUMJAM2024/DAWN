using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Queue<Enums.Menu> menuQueue = new Queue<Enums.Menu>(8);
    public Enums.Menu servingMenu = Enums.Menu.None;
    public bool isServing = false;

    [SerializeField] GameObject cake;
    [SerializeField] GameObject bread;
    [SerializeField] GameObject coffee;

    public void ShowServedFood(Enums.Menu menu, bool isShow)
    {
        if (!isShow)
        {
            servingMenu = Enums.Menu.None;
        }
        if (menu == Enums.Menu.bread)
        {
            bread.SetActive(isShow);
        }

        if (menu == Enums.Menu.cake)
        {
            cake.SetActive(isShow);
        }

        if (menu == Enums.Menu.coffee)
        {
            coffee.SetActive(isShow);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ShowServedFood(servingMenu, false);
            servingMenu = Enums.Menu.None;
        }
    }
}