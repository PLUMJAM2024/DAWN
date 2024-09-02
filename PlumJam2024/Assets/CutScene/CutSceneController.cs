using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool isTimelineFinished = false;
    private bool isFirst = true;
    [SerializeField] Text text;

    void Start()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    void Update()
    {
        if (isTimelineFinished && isFirst)
        {
            isFirst = false;
            text.gameObject.SetActive(true);

        }
        if (isTimelineFinished && Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        isTimelineFinished = true;
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Player");
    }
}