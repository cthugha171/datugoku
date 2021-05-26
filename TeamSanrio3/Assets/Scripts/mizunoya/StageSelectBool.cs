using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBool : MonoBehaviour
{
    private bool isColObj = false;

    public bool IsColObj
    {
        get => isColObj;
        set => isColObj = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isColObj = true;
        }
    }
}
