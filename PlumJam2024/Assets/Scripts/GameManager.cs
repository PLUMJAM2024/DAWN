using System.Collections;
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
            if(currentBalloon < totalBalloon) {
                currentBalloon++;
            }
        }
        else {
            if(currentBalloon > 0) {
                currentBalloon--;
            }
        }
    }

    IEnumerator ToResultClear() {
        Debug.LogError("게임 클리어 표시 미구현");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Clear");
    }

    IEnumerator ToResultFail() {
        Debug.LogError("게임 실패 표시 미구현");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Fail");
    }

    void UpdateTimer() {
        totalGameTime -= Time.deltaTime;
        txt_timer.text = totalGameTime.ToString("N0");
        if (totalGameTime < 0) {
            isGame = false;
            StartCoroutine(ToResultFail());
        }
    }

    void UpdateBalloon() {
        sld_balloon.value = currentBalloon;
        txt_balloon.text = $"{currentBalloon} / {totalBalloon}";
        if(currentBalloon >= totalBalloon) {
            isGame = false;
            StartCoroutine(ToResultClear());
        }
    }
}
