using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isKey = false;

    public bool IsKey
    {
        get => isKey;
        set => isKey = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            isKey = true;
            SoundManager.Instance.PlaySeByName("鍵を拾った時");
        }
    }
}
