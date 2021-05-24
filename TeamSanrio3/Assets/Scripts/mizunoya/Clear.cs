using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
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
        //ここにクリアしたときのflagを入れる
        if(Input.GetKeyDown(KeyCode.C))
        {
            change.ChangeScene();
        }
    }
}
