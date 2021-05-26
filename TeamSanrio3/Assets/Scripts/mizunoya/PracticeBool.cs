using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeBool : MonoBehaviour
{
    private bool isColObj = false;

    public bool IsColObj
    {
        get => isColObj;
        set => isColObj = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isColObj = true;
            Debug.Log("箱");
        }
    }
}
