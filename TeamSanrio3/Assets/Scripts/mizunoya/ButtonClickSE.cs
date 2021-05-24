using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSE : MonoBehaviour
{
    private SoundManager soundManager;

    private void Start()
    {
        //サウンドマネージャーをアタッチ
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnClick()
    {
        soundManager.PlaySeByName("ボタンを押したとき");
    }
}
