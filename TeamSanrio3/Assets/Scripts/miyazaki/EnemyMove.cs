using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    //参照オブジェ
    public GameObject enemy2;
    public GameObject onTargetUI;

    private int count = 0;

    [SerializeField]
    private float countTime;
    private float time;

    [SerializeField]
    private float Interval;
    PlayerCon playerCon;
    Vector2 rot;
    private Vector3 velocity;
    private Rigidbody rb;

    [SerializeField, Header("巡回する場所")]
    private Transform[] patrolPoint;
    [SerializeField, Header("生成する場所")]
    private Transform[] instantiate;
    [SerializeField, Header("移動スピード")]
    float MoveSpeed;
    [SerializeField, Header("移動スピード")]

    float TargetOnSpeed = 2f;

    private int currentPoint = 0;

    bool OnTarget = false;
    bool TargetOFF = true;
    bool onSound = false;

    public bool Anime = false;
    public bool isFound = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = FindObjectOfType<PlayerCon>();
        onTargetUI.SetActive(false);
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (playerCon.IsDeadFlag)
        {
            TargetOFF = false;
            OnTarget = false;
        }
        Move();
    }
    public void Move()
    {
        Vector3 pv = player.transform.position;

        Vector3 ev = transform.position;

        float p_vX = pv.x - ev.x;
        float p_vY = pv.y - ev.y;

        float vx = 0f;
        float vy = 0f;

        //ステージの巡回処理
        if (TargetOFF)
        {
            Anime = true;

            isFound = false;

            var vec = patrolPoint[currentPoint].position - transform.position;

            //y軸固定
            vec.y = 0;

            //z軸を固定
            vec.z = 0;

            transform.position += vec.normalized * MoveSpeed * Time.deltaTime;


            if (vec.magnitude < 0.1f)
            {
                currentPoint = (currentPoint + 1) % 2;
            }

            // スケール値取り出し
            Vector3 scale = transform.localScale;
            if (vec.x > 0)
            {
                // 右方向に移動中
                scale.x = -1; // そのまま（右向き）
            }
            if (vec.x < 0)
            {
                // 左方向に移動中
                scale.x = 1; // 反転する（左向き）
            }
            // 代入し直す
            transform.localScale = scale;
        }

        if (OnTarget)
        {

            count++;
            // 減算した結果がマイナスであればXは減算処理
            if (p_vX < 0)
            {
                vx = -TargetOnSpeed;
            }
            //加算した結果がプラスであればXは加算処理
            else
            {
                vx = TargetOnSpeed;
            }

            transform.Translate(vx / 45, vy / 45, 0);
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
            // CubeプレハブをGameObject型で取得
            countTime += Time.deltaTime;
            if (countTime>=Interval)
            {
                Debug.Log("時間"+countTime);
                countTime = 0.0f;
                //増援処理
                for (int i = 0; i < instantiate.Length; i++)
                {
                    Instantiate(enemy2, new Vector3(instantiate[i].position.x, instantiate[i].position.y, instantiate[i].position.z), Quaternion.identity);
                }
            }   
        }
    }
    //カメラに映っているときだけ足音が聞こえるように
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
    //検知エリアに入っとき
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFound = true;

            onTargetUI.SetActive(true);

            OnTarget = true;

            TargetOFF = false;

            if (!onSound)
            {

                onSound = true;

                //SE再生
                SoundManager.Instance.PlaySeByName("発見SE");

            }
        }

    }
    //検知から外れたとき
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onSound = false;
            OnTarget = false;
            TargetOFF = true;

            onTargetUI.SetActive(false);
            count = 0;
        }
    }
    //当たり判定に触れたとき
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCon.IsDeadFlag = true;
        }
    }
}