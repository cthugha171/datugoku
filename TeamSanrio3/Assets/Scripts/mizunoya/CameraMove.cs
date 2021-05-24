using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform cameraPos;
    private Vector3 position;
    private float movecamPosX;

    public float posZ = 0.0f;
    public float moveX = 0.0f;
    public GameObject player;
    [Tooltip("カメラのY座標初期位置")] public float cameraPosY = 0.5f;
    [Tooltip("最初の画面外を移さないようにするX座標値")] public float startlimitcameraPosX = 0.0f;
    [Tooltip("最後の画面外を移さないようにするX座標値")] public float lastlimitcameraPosX = 0.0f;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GetComponent<Transform>();

        if (cameraPos == null || player == null)
        {
            return;
        }
        position = new Vector3(0, cameraPosY, posZ);

        Debug.Log("Screen Width" + Screen.width);
        Debug.Log("Screen Height" + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        //AutoMove();
        //PlayerMoveCamera();
        LimitsCameraMove();
    }

    /// <summary>
    /// 自動でカメラがX移動する
    /// </summary>
    public void AutoMove()
    {
        position.x += moveX;
        cameraPos.position = position;
    }

    /// <summary>
    /// プレイヤーが動いたらカメラも追従する
    /// </summary>
    public void PlayerMoveCamera()
    {
        transform.position = new Vector3(player.transform.position.x, position.y, position.z);
    }

    /// <summary>
    /// ステージ外を移さないようにするカメラ
    /// </summary>
    public void LimitsCameraMove()
    {
        movecamPosX = player.transform.position.x;

        if (movecamPosX <= startlimitcameraPosX)
        {
            movecamPosX = startlimitcameraPosX;
        }
        if (movecamPosX >= lastlimitcameraPosX)
        {
            movecamPosX = lastlimitcameraPosX;
        }
        //Debug.Log(movecamPosX);
        transform.position = new Vector3(movecamPosX, position.y, position.z);
    }
}
