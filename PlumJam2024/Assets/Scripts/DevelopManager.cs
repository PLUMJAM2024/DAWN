using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopManager : MonoBehaviour
{
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if(hit.collider != null) {
                GameObject target = hit.collider.gameObject;

                if(target.GetComponent<Customer>() != null) {
                    if (!target.GetComponent<Customer>().isOrdered) {
                        target.GetComponent<Customer>().isOrdered = true;
                    }
                    else {
                        if(target.GetComponent<Customer>().isReceived) {
                            target.GetComponent<Customer>().isReceived = true;
                        }
                    }
                }
            }
        }
    }
}
