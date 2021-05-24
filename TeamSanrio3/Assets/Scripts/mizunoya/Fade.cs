using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 0.0f;//フェード時間

    //public bool isFadeOut = false;//フェードアウト
    //public bool isFadeIn = false;//フェードイン
    public string NextChangeSceneName;//次のシーンの名前

    private float red, green, blue, alfa;//パネルの色、透明度
    private Image fadePanelImage;
    private bool isStart = true;
    private SceneChange sceneChange;
    private PlayerCon player;
    private Goal goal;
    private bool isLoadScene = false;

    private void Start()
    {
        fadePanelImage = GetComponent<Image>();
        red = fadePanelImage.color.r;
        green = fadePanelImage.color.g;
        blue = fadePanelImage.color.b;
        alfa = fadePanelImage.color.a;
        sceneChange = FindObjectOfType<SceneChange>();
        player = FindObjectOfType<PlayerCon>();
        goal = FindObjectOfType<Goal>();
    }

    private void Update()
    {
        if (SceneSave.Instance.IsNowScene.Contains("Stage"))
        {
            if (player.IsDeadFlag)
            {
                StartFadeOut();

                if (isLoadScene)
                {
                    sceneChange.ChangeScene("GameOver");
                }
            }

            if (goal.IsGoal)
            {
                StartFadeOut();

                if (isLoadScene)
                {
                    sceneChange.ChangeScene("Clear");
                }
            }
        }
    }

    private void StartFadeIn()
    {
        if (isStart)
        {
            fadePanelImage.enabled = true;
            isStart = false;
        }

        alfa -= fadeSpeed;
        SetAlpha();
        if (alfa <= 0)
        {
            //isFadeIn = false;
            fadePanelImage.enabled = false;//パネルの表示をオフにする
            isLoadScene = true;
        }
    }

    private void StartFadeOut()
    {
        if (isStart)
        {
            alfa = 0;
            SetAlpha();
            isStart = false;
        }

        fadePanelImage.enabled = true;//パネルの表示をオンにする
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1)
        {
            //isFadeOut = false;
            isLoadScene = true;
        }
    }

    private void SetAlpha()
    {
        fadePanelImage.color = new Color(red, green, blue, alfa);
    }
}
