using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner instance;

    [Header("Positions")]
    public Sit[] sits;
    public Transform enterance;

    [Header("Prefabs")]
    public GameObject pre_customer;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.LogAssertion("�մ� �ڵ� ���� �̱���");
            SpawnCustomer();
        }
    }

    void SpawnCustomer() {
        bool isfull = true;
        foreach (var s in sits) {
            isfull &= s.isUsing;
        }

        if (isfull){
            print("��� �ڸ��� ������");
            return;
        }

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
