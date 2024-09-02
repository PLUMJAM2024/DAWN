using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Queue<Enums.Menu> menuQueue = new Queue<Enums.Menu>(8);
    public Enums.Menu servingMenu = Enums.Menu.None;
    public bool isServing = false;

    [SerializeField] GameObject cheesecake;
    [SerializeField] GameObject chocolatecake;
    [SerializeField] GameObject cookiecheesecake;
    [SerializeField] GameObject croissant;
    [SerializeField] GameObject pancake;
    [SerializeField] GameObject chocolatepancake;
    [SerializeField] GameObject tirimasu;

    public GameObject[] completeFood = new GameObject[5];

    public void ShowServedFood(Enums.Menu menu, bool isShow)
    {
        if (!isShow)
        {
            servingMenu = Enums.Menu.None;
        }
        if (menu == Enums.Menu.cheesecake) {
            cheesecake.SetActive(isShow);
        }
        if (menu == Enums.Menu.chocolatecake) {
            chocolatecake.SetActive(isShow);
        }
        if (menu == Enums.Menu.cookiecheesecake) {
            cookiecheesecake.SetActive(isShow);
        }
        if (menu == Enums.Menu.croissant) {
            croissant.SetActive(isShow);
        }
        if (menu == Enums.Menu.pancake) {
            pancake.SetActive(isShow);
        }
        if (menu == Enums.Menu.chocolatepancake) {
            chocolatepancake.SetActive(isShow);
        }
        if (menu == Enums.Menu.tirimasu) {
            tirimasu.SetActive(isShow);
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ShowServedFood(servingMenu, false);
            servingMenu = Enums.Menu.None;
            isServing = false;
        }
    }
}