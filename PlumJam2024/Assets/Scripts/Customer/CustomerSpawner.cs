using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner instance;

    [Header("Positions")]
    public Sit[] sits;
    public Transform enterance;

    [Header("UIs")]
    public GameObject ready;
    public GameObject go;

    [Header("Prefabs")]
    public GameObject[] pre_customer;

    public void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart() {
        GameManager.instance.isGame = false;
        ready.SetActive(true);
        go.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        ready.SetActive(false);
        go.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        go.SetActive(false);
        GameManager.instance.isGame = true;
        while (GameManager.instance.isGame && GameManager.instance.totalGameTime > 0) {
            SpawnCustomer();
            yield return new WaitForSeconds(Random.Range(0, 16));
        }
    }

    void SpawnCustomer() {
        bool isfull = true;
        foreach (var s in sits) {
            isfull &= s.isUsing;
        }

        if (isfull){
            print("모든 자리가 가득참");
            return;
        }

        int idx = Random.Range(0, sits.Length);
        Sit selected_sit = sits[idx];
        while (selected_sit.isUsing) {
            idx = Random.Range(0, sits.Length);
            selected_sit = sits[idx];
        }
        GameObject customer = Instantiate(pre_customer[Random.Range(0, pre_customer.Length)], enterance.position, Quaternion.identity);
        customer.GetComponent<Customer>().init(selected_sit);
        GameManager.instance.Customers.Add(customer);
    }
}
