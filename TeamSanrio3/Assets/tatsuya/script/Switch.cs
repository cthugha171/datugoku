using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch: MonoBehaviour
{
    [SerializeField] private string plTag = "Player";
    [SerializeField] private GameObject Laser;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider collider;
    [SerializeField] private Vector3 colSizeOn;
    [SerializeField] private Vector3 colSizeOff;
    [SerializeField] private Vector3 colCenterOn;
    [SerializeField] private Vector3 colCenterOff;


    //設定したゲームオブジェクトのアクティブ設定と同じにする
    [SerializeField] private bool preSet = true;

    void Start()
    {
        animator.SetBool("switching", preSet);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == plTag)
        {
            preSet = false;
            animator.SetBool("switching", preSet);
            SoundManager.Instance.PlaySeByName("ボタンOBJを押したとき");
            Laser.SetActive(preSet);
        }
        if (preSet==false)
        {
            collider.center = colCenterOn;
            collider.size = colSizeOn;
        }
        else
        {
            collider.center = colCenterOff;
            collider.size = colSizeOff;
        }
    }
}
