using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private SceneChange change;

    // Start is called before the first frame update
    void Start()
    {
        change = GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        //ここにゲームオーバーしたときのflagを入れる
        if (Input.GetKeyDown(KeyCode.O))
        {
            change.ChangeScene();
        }
    }
}
