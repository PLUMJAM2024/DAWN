using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool isPaused = false;  // 타임라인의 일시 중지 상태를 추적

    void Update()
    {
        // 스페이스바가 눌렸는지 확인
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                // 타임라인이 일시 중지된 상태라면 재개
                playableDirector.Play();
                isPaused = false;
            }
            else if (playableDirector.playableGraph.IsPlaying())
            {
                // 타임라인이 재생 중이면 일시 중지
                playableDirector.Pause();
                isPaused = true;
            }
            else
            {
                // 타임라인이 종료되었으면 다음 장면으로 전환
                NextScene();
            }
        }
    }

    void NextScene()
    {
        // 여기서 다음 장면으로 넘어가는 코드를 작성
        // 예: SceneManager.LoadScene("NextSceneName");
        Debug.Log("Next Scene Loading...");
    }
}
