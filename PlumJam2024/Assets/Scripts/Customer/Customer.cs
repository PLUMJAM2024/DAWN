using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    public List<Transform> waypoints = new List<Transform>();
    public CustomerStateMachine stateMachine;
    public Enums.Menu menu;
    public float orderWatingTime;
    public float menuWatingTime;
    public readonly float enjoyingTime = 2f;
    public readonly float moveSpeed = 3f;

    private void Start() {
        stateMachine = gameObject.AddComponent<CustomerStateMachine>();
    }

    public void init(Sit dest) {
        for(int i = 0; i < dest.wayPoints.Count; i++) {
            waypoints.Add(dest.wayPoints[i]);
        }
        waypoints.Add(dest.transform);
        orderWatingTime = Random.Range(4, 8);
        menuWatingTime = Enums.MenuTime[menu] + Random.Range(4, 8);
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
