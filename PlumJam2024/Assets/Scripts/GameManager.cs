using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    public bool isGame = true;
    public float totalGameTime = 180;

    [Header("UI")]
    public TMP_Text txt_timer;
    public TMP_Text txt_balloon;

    private void FixedUpdate() {
        if (isGame) {
            UpdateTimer();

        }
    }

    void UpdateTimer() {
        totalGameTime -= Time.deltaTime;
        txt_timer.text = totalGameTime.ToString("N0");
        if (totalGameTime < 0) {
            isGame = false;
        }
    }
}
