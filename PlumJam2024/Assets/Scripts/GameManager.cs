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
    public bool isGame = false;
    public float totalGameTime = 75;
    public int totalBalloon = 40;
    public int currentBalloon = 0;
    public AudioClip pop;

    [Header("UI")]
    public TMP_Text txt_timer;
    public TMP_Text txt_balloon;
    public Slider sld_balloon;
    public GameObject finish;

    private AudioSource audio;
    public List<GameObject> Customers = new List<GameObject>();

    private void Awake() {
        instance = this;
        audio = GetComponent<AudioSource>();
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
            currentBalloon += Random.Range(3, 8);
        }
        else {
            currentBalloon -= Random.Range(1, 4);
            audio.clip = pop;
            audio.Play();
            if (currentBalloon < 0) {
                currentBalloon = 0;
            }
        }
    }

    IEnumerator ToResultClear() {
        finish.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Clear");
    }

    IEnumerator ToResultFail() {
        finish.SetActive(true);
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
