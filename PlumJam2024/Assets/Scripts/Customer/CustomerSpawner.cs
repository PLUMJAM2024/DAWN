using System.Collections;
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

    private void Start() {
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart() {
        Debug.LogError("�غ� ���̱� �̱���");
        yield return new WaitForSeconds(1.5f);
        Debug.LogError("���� ���̱� �̱���");
        yield return new WaitForSeconds(1.5f);
        while (GameManager.instance.isGame) {
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
