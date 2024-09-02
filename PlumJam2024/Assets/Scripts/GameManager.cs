using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
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

    void UpdateTimer() {
        totalGameTime -= Time.deltaTime;
        txt_timer.text = totalGameTime.ToString("N0");
        if (totalGameTime < 0) {
            isGame = false;
            Debug.LogError("게임 실패 미구현");
        }
    }

    void UpdateBalloon() {
        sld_balloon.value = currentBalloon;
        txt_balloon.text = $"{currentBalloon} / {totalBalloon}";
        if(currentBalloon >= totalBalloon) {
            isGame = false;
            Debug.LogError("게임 클리어 미구현");
        }
    }
}
