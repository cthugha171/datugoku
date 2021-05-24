using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMove : MonoBehaviour
{
    [SerializeField, Header("巡回する場所")]
    private Transform[] patrolPoint;
    [SerializeField, Header("移動スピード")]
    float MoveSpeed;
    private int currentPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }
    void Move()
    {
        var vec = patrolPoint[currentPoint].position - transform.position;

        vec.y = 0;

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
}
