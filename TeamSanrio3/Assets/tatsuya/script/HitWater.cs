using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitWater : MonoBehaviour
{
    [SerializeField] private GameObject electric;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private bool isElectric;
    [SerializeField] private float interval=20.0f;
    [SerializeField] private float count = 0;
    private PlayerCon player;


    void Start()
    {
        player = FindObjectOfType<PlayerCon>();
        isElectric = false;
    }

    private void Update()
    {
        count += Time.deltaTime;

        if(count>=interval)
        {
            isElectric = !isElectric;
            count = 0.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag&&isElectric==true)
        {
            player.IsDeadFlag = true;
            Debug.Log(player.IsDeadFlag);
        }
    }
}
