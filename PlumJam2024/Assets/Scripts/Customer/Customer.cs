using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
    public List<Transform> waypoints = new List<Transform>();
    public Sit sit;
    public CustomerStateMachine stateMachine;
    public MenuSO menu;
    public float orderWaitingTime;
    public bool isOrdered = false;
    public float menuWaitingTime;
    public bool isReceived = false;
    public float enjoyingTime = 2f;
    public readonly float moveSpeed = 3f;
    public GameObject canvas;
    public Image emoji;
    public Image timer;
    public Animator animator;

    private void Awake() {
        stateMachine = gameObject.AddComponent<CustomerStateMachine>();
        animator = GetComponent<Animator>();
        canvas.gameObject.SetActive(false);
    }

    public void init(Sit dest, bool reverse = false) {
        //var enumValue = System.Enum.GetValues(enumType:typeof(MenuSO)); 
        //menu = (MenuSO)enumValue.GetValue(Random.Range(1, enumValue.Length));
        menu = DataManager.instance.GetRandomMenu();

        if (!reverse) {
            for (int i = 0; i < dest.wayPoints.Count; i++) {
                waypoints.Add(dest.wayPoints[i]);
            }
            waypoints.Add(dest.transform);
            sit = dest;
            orderWaitingTime = Random.Range(8, 16);
            menuWaitingTime = menu.GetCookingTime() + Random.Range(12, 18);
        }
        else {
            for (int i = dest.wayPoints.Count - 1; i >= 0; i--) {
                waypoints.Add(dest.wayPoints[i]);
            }
            waypoints.Add(CustomerSpawner.instance.enterance);
        }
    }

    public void Update() { 
        stateMachine.CurrentState._Update();
    }

    public void ReceiveMenu(MenuSO menu) {
        if(this.menu.name != menu.name) {
            Debug.LogError("잘못된 메뉴 전달");
            return; 
        }
    }

    public void OnDestroy() {
        GameManager.instance.Customers.Remove(gameObject);
    }
}
