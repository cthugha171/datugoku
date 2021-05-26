using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needle : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private PlayerCon player;

    void Start()
    {
        player = FindObjectOfType<PlayerCon>();
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==playerTag)
        {
            player.IsDeadFlag = true;
        }
    }
}
