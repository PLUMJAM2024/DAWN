using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [Header("Positions")]
    public Sit[] sits;
    public Transform enterance;

    [Header("Prefabs")]
    public GameObject pre_customer;
    

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            print("good");
            SpawnCustomer();
        }
    }

    void SpawnCustomer() {
        int idx = Random.Range(0, sits.Length);
        Sit selected_sit = sits[idx];
        while (selected_sit.isUsing) {
            idx = Random.Range(0, sits.Length);
            selected_sit = sits[idx];
        }
        GameObject customer = Instantiate(pre_customer, enterance.position, Quaternion.identity);
        customer.GetComponent<Customer>().init(selected_sit);
    }
}
