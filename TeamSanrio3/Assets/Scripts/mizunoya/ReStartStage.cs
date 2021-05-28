using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStartStage : MonoBehaviour
{
    private SceneSave sceneSave;
    private string restartScene;
    private SceneChange sceneChange;

    public void ReStartGame()
    {
        sceneSave = FindObjectOfType<SceneSave>();
        sceneChange = FindObjectOfType<SceneChange>();
        restartScene = sceneSave.BeforScene;
        sceneChange.ChangeScene(restartScene);
    }
}
