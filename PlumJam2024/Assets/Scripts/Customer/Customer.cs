using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    public List<Transform> waypoints = new List<Transform>();
    public Sit sit;
    public CustomerStateMachine stateMachine;
    public Enums.Menu menu;
    public float orderWatingTime;
    public bool isOrdered = false;
    public float menuWatingTime;
    public bool isReceived = false;
    public float enjoyingTime = 2f;
    public readonly float moveSpeed = .3f;
    public GameObject speechBubble;
    public GameObject emoji;
    public Animator animator;

    private void Start() {
        stateMachine = gameObject.AddComponent<CustomerStateMachine>();
        animator = GetComponent<Animator>();
        speechBubble.SetActive(false);
    }

    public void init(Sit dest, bool reverse = false) {
        var enumValue = System.Enum.GetValues(enumType:typeof(Enums.Menu)); 
        menu = (Enums.Menu)enumValue.GetValue(Random.Range(0, enumValue.Length));

        if(!reverse) {
            for (int i = 0; i < dest.wayPoints.Count; i++) {
                waypoints.Add(dest.wayPoints[i]);
            }
            waypoints.Add(dest.transform);
            sit = dest;
            orderWatingTime = Random.Range(4, 8);
            menuWatingTime = Enums.MenuTime[menu] + Random.Range(99, 100);
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

    public void ReceiveMenu(Enums.Menu menu) {
        if(this.menu != menu) {
            Debug.LogError("잘못된 메뉴 전달");
            return; 
        }

    }
}
