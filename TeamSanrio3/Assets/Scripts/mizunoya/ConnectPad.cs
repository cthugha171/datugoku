using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPad : MonoBehaviour
{
    //private string[] controllerNames;
    private bool isConnect = false;

    private void Awake()
    {
        //接続されているコントローラーの名前を調べる
        var controllerNames = Input.GetJoystickNames();
        Debug.Log(controllerNames[0]);

        //一台もコントローラーが接続されていなければエラー
        //名前が入っていなかったら
        if (controllerNames[0] == "")
        {
            Debug.Log("コントローラーがないよ");
            //コントローラーが接続されていない
            isConnect = false;
            return;
        }
        //コントローラー接続している
        isConnect = true;
    }

    public bool IsConnect()
    {
        return isConnect;
    }
}
