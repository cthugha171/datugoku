using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2Move : MonoBehaviour
{
    private GameObject player;
    PlayerCon playerCon;
    //Animator animator;
    //private SoundManager soundManager;
    [SerializeField, Header("移動スピード")]
    float TargetOnSpeed = 2f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = FindObjectOfType<PlayerCon>();
        //animator = GetComponent<Animator>();
        //サウンドマネージャーをアタッチ
        //soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        Move();
        //animator.SetFloat("Speed", 1.0f);
    }
     void Move()
    {
        
        Vector3 pv = player.transform.position;
        Vector3 ev = transform.position;

        float p_vX = pv.x - ev.x;
        float p_vY = pv.y - ev.y;

        float vx = 0f;
        float vy = 0f;

        // 減算した結果がマイナスであればXは減算処理
        if (p_vX < 0)
        {
            vx = -TargetOnSpeed;
        }
        else
        {
            vx = TargetOnSpeed;
        }

        transform.Translate(vx / 50, vy / 50, 0);
        Vector3 scale = transform.localScale;
        if (vx > 0)
        {
            // 右方向に移動中
            scale.x = -1; // そのまま（右向き）
        }
        if (vx < 0)
        {
            // 左方向に移動中
            scale.x = 1; // 反転する（左向き）
        }
        // 代入し直す
        transform.localScale = scale;
        if(playerCon.IsDeadFlag)
        {
            vx = 0;
        }
        Destroy(this.gameObject, 5.0f);
    }
    void OnWillRenderObject()

    {

#if UNITY_EDITOR
        time += Time.deltaTime;
        if (Camera.current.name != "SceneCamera" && Camera.current.name != "Preview Camera")

#endif

        {
            if (time > 0.5f)
            {
                SoundManager.Instance.PlaySeByName("足音");
                time = 0;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCon.IsDeadFlag = true;
            Debug.Log(playerCon.IsDeadFlag);
        }
    }
}
