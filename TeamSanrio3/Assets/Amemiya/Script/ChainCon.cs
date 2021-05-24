using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCon : MonoBehaviour
{
    public float angle = 0.0f;
    Vector3 scale = new Vector3(20.0f, 100.0f, 20.0f);
    public Vector3 angles = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 direction;
    Vector3 targetpos;
    public bool chain;
    public bool hitflag;
    public bool blockhit;
    public bool click;
    public GameObject player;
    public GameObject target;
    public static int success;
    public static int play;
    public static int failure;
    PlayerCon playerCon;
    private float time;
    public Rigidbody rb;
    Transform tr;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        success = 0;
        play = 0;
        failure = 0;
        chain = false;
        hitflag = false;
        blockhit = false;
        click = false;
        playerCon = player.gameObject.GetComponent<PlayerCon>();
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        MouseUpdata();
       // ConUpdata();
    }

    private void MouseUpdata()
    {
        time += Time.deltaTime;
        //左クリックを押したときの角度取得 鎖が当たってない時
        if (Input.GetMouseButtonDown(0) && hitflag == false)
        {
            BoxCollider boxcol = gameObject.GetComponent<BoxCollider>();
            // プレイヤーのスクリーン座標を計算する
            var screenPos = Camera.main.WorldToScreenPoint(transform.position);

            // プレイヤーから見たマウスカーソルの方向を計算する
            direction = Input.mousePosition - screenPos;

            // マウスカーソルが存在する方向の角度を取得する
            angle = GetAim(Vector3.zero, direction);

            
            play++;
        }
        if (Input.GetButtonDown("Action") && hitflag == false)
        {
            var screenPos = Camera.main.WorldToScreenPoint(transform.position);
            // プレイヤーから見たマウスカーソルの方向を計算する
            direction = Camera.main.WorldToScreenPoint(target.transform.position) - screenPos;
            // マウスカーソルが存在する方向の角度を取得する
            angle = GetAim(Vector3.zero, direction);
            play++;
        }
        //左クリックを押し続けた時の角度取得と鎖伸ばし
        if (Input.GetMouseButton(0) && hitflag == false &&playerCon.jump == true
        || Input.GetButton("Action") && hitflag == false && playerCon.jump == true
        || Input.GetMouseButton(0) && hitflag == false && playerCon.jump == false && playerCon.angles.z == 0
        || Input.GetButton("Action") && hitflag == false && playerCon.jump == false && playerCon.angles.z == 0)
        {
            // プレイヤーがマウスカーソルの方向を見るようにする
            angles = tr.localEulerAngles;
            angles.z = angle - 90;
            tr.localEulerAngles = angles;
            tr.localScale = scale;
            scale.y += 1.5f;
            click = true;
            
            if (time > 0.5f)
            {
                soundManager.PlaySeByName("手錠を伸ばす");
                time = 0;
            }
        }
        else
        {
            click = false;
        }
        //鎖が当たった時に角度を取得する
        if (hitflag == true && chain == false)
        {
            targetpos = target.gameObject.transform.position;
            angles = tr.localEulerAngles;
            angles.z = angle - 90;
            player.transform.localEulerAngles = angles;
            tr.eulerAngles = angles;
            scale.y = scale.y / 1.5f;
            tr.localScale = scale;
            chain = true;
            soundManager.PlaySeByName("手錠がひっかる音");
        }
        //鎖が当たってないときに鎖の角度と伸縮をリセット
        if (Input.GetMouseButtonUp(0) && hitflag == false  ||Input.GetButtonUp("Action") && hitflag == false
            ||hitflag == false && blockhit == true || hitflag == false && scale.y > 50.0f)
        {
            scale.y = 0.0f;
            tr.localScale = scale;
            var angles = tr.localEulerAngles;
            angles.x = 0.0f;
            angles.y = 0.0f;
            angles.z = 0.0f;
            tr.localEulerAngles = angles;
            
            failure++;
            blockhit = false;
        }
        //鎖当たっている時の鎖解除と鎖の伸縮をリセット
        if (Input.GetMouseButtonDown(1) && hitflag == true || Input.GetButtonDown("Action2") && hitflag == true)
        {
            scale.y = 0.0f;
            tr.localScale = scale;
            var angle = new Vector3();
            //angle.z = 0.0f;
            //player.transform.localEulerAngles = angle;
            playerCon.rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            //playerCon.rb.constraints = RigidbodyConstraints.None;
            success++;
            chain = false;
            hitflag = false;
            
        }
        if(chain == false)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX |
RigidbodyConstraints.FreezeRotationY;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if(chain == true)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public float GetAim(Vector2 from, Vector2 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Object"&&click ==true)
        {
            hitflag = true;
        }
        if (collision.gameObject.name == "block(Clone)" && click == true)
        {
            blockhit = true;
           // Debug.Log("ブロック");
        }
    }
}
