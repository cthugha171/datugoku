using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeActiv : MonoBehaviour
{
    public GameObject volumeUIPrefab;

    private bool isVolume = false;

    public bool IsVolume
    {
        get => isVolume;
        set => isVolume = value;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void ActiveVolume(GameObject VolumeUIPrefab)
    {
        VolumeUIPrefab.SetActive(true);
        Time.timeScale = 0f;
        isVolume = true;
    }

    public void FlseActiveVolume(GameObject VolumeUIPrefab)
    {
        VolumeUIPrefab.SetActive(false);
        Time.timeScale = 1f;
        isVolume = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ActiveVolume(volumeUIPrefab);
        }
    }
}
