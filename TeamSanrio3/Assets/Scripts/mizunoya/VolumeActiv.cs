using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeActiv : MonoBehaviour
{
    private bool isVolume = false;

    public bool IsVolume
    {
        get => isVolume;
        set => isVolume = value;
    }

    public void ActiveVolume(GameObject VolumeUIPrefab)
    {
        VolumeUIPrefab.SetActive(true);
        isVolume = true;
    }

    public void FlseActiveVolume(GameObject VolumeUIPrefab)
    {
        VolumeUIPrefab.SetActive(false);
        isVolume = true;
    }
}
