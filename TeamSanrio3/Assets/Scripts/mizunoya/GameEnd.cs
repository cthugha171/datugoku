using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetButtonDown("BACK"))
        {
            Debug.Log("終わり");
            End();
        }
    }

    public void End()
    {
        //ゲームを終了
        Application.Quit();
    }
}
