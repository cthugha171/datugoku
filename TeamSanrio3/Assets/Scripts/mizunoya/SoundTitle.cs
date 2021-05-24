using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTitle : MonoBehaviour
{

    void Start()
    {
        //BGM再生
        SoundManager.Instance.PlayBgmByName("タイトルBGM");
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //SE再生
            SoundManager.Instance.PlaySeByName("発見SE2");
        }
    }
}
