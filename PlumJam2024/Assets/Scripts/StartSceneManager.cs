using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void btn_Start() {
        SceneManager.LoadScene("Player");
    }

    public void btn_Quit() {
        Application.Quit();
    }

    public void btn_StartScene() {
        SceneManager.LoadScene("Start");
    }
}
