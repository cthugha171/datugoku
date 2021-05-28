using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSave : SingletonMonoBehaviour<SceneSave>
{
    private string beforeScene;
    private string nowScene;

    public string BeforScene
    {
        get => beforeScene;
        set => beforeScene = value;
    }

    public string IsNowScene
    {
        get => nowScene;
        set => nowScene = value;
    }

    private void Awake()
    {
        nowScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        NowScene();
    }

    public void NowScene()
    {
        nowScene = SceneManager.GetActiveScene().name;

        if (nowScene.Contains("Stage"))
        {
            beforeScene = nowScene;
        }
    }

    public string GetBeforeScene()
    {
        return beforeScene;
    }
}
