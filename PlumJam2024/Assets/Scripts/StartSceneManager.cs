using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void btn_Start() {
        SceneManager.LoadScene("CutScene");
    }

    public void btn_Quit() {
        Application.Quit();
    }

    public void btn_StartScene() {
        SceneManager.LoadScene("Start");
    }
}
