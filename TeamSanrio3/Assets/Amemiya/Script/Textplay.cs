using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textplay : MonoBehaviour
{
    public Text TextPlay;
    public Text TextSuccess;
    public Text TextFailure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextPlay.text = string.Format("{000} 回数", ChainCon.play);
        TextSuccess.text = string.Format("{000} 成功", ChainCon.success);
        TextFailure.text = string.Format("{000} 失敗", ChainCon.failure);
    }
    
}
