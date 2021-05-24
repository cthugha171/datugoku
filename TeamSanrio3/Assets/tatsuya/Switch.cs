using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch: MonoBehaviour
{
    [SerializeField] private string plTag = "Player";
    [SerializeField] private GameObject Laser;
    [SerializeField] private Animator animator;

    //設定したゲームオブジェクトのアクティブ設定と同じにする
    [SerializeField] private bool preSet = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == plTag)
        {
            preSet = !preSet;
            animator.SetBool("switching", preSet);
            Laser.SetActive(preSet);
        }
    }
}
