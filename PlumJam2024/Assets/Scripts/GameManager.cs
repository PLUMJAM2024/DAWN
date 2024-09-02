using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Data")]
    public bool isGame = true;
    public float totalGameTime = 180;
    public int totalBalloon = 70;
    public int currentBalloon = 0;

    [Header("UI")]
    public TMP_Text txt_timer;
    public TMP_Text txt_balloon;
    public Slider sld_balloon;

    public List<GameObject> Customers = new List<GameObject>();

    private void Awake() {
        instance = this;
    }

    private void Start() {
        sld_balloon.maxValue = totalBalloon;
    }

    private void Update() {

    }

    private void FixedUpdate() {
        if (isGame) {
            UpdateTimer();
            UpdateBalloon();
        }
    }

    public void AddBalloon(bool plus) {
        if (plus) {
            currentBalloon += Random.Range(1, 10);
        }
        else {
            currentBalloon -= Random.Range(1, 5);
            if (currentBalloon < 0) {
                currentBalloon = 0;
            }
        }
    }

    IEnumerator ToResultClear() {
        Debug.LogError("���� Ŭ���� ǥ�� �̱���");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Clear");
    }

    IEnumerator ToResultFail() {
        Debug.LogError("���� ���� ǥ�� �̱���");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Fail");
    }

    void UpdateTimer() {
        totalGameTime -= Time.deltaTime;
        if (totalGameTime < 0 && GameManager.instance.Customers.Count <= 0) {
            isGame = false;
            if(totalBalloon > currentBalloon) {
                StartCoroutine(ToResultFail());
            }
            else {
                StartCoroutine(ToResultClear());
            }
        }
        else {
            txt_timer.text = Mathf.Max(totalGameTime, 0).ToString("N0");
        }
    }

    void UpdateBalloon() {
        sld_balloon.value = currentBalloon;
        txt_balloon.text = $"{currentBalloon} / {totalBalloon}";
    }
}
