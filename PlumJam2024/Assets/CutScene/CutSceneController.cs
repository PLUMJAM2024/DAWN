using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool isPaused = false;  // Ÿ�Ӷ����� �Ͻ� ���� ���¸� ����

    void Update()
    {
        // �����̽��ٰ� ���ȴ��� Ȯ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                // Ÿ�Ӷ����� �Ͻ� ������ ���¶�� �簳
                playableDirector.Play();
                isPaused = false;
            }
            else if (playableDirector.playableGraph.IsPlaying())
            {
                // Ÿ�Ӷ����� ��� ���̸� �Ͻ� ����
                playableDirector.Pause();
                isPaused = true;
            }
            else
            {
                // Ÿ�Ӷ����� ����Ǿ����� ���� ������� ��ȯ
                NextScene();
            }
        }
    }

    void NextScene()
    {
        // ���⼭ ���� ������� �Ѿ�� �ڵ带 �ۼ�
        // ��: SceneManager.LoadScene("NextSceneName");
        Debug.Log("Next Scene Loading...");
    }
}
