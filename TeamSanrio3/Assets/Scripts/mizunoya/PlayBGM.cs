using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    public string playBGM;

    private void Awake()
    {
        if (SoundManager.Instance.IsPlayBGM)
        {
            SoundManager.Instance.StopBgm();
        }
    }

    private void Start()
    {
        SoundManager.Instance.PlayBgmByName(playBGM);
    }
}
