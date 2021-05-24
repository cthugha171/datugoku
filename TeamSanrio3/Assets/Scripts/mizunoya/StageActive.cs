using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActive : MonoBehaviour
{
    public GameObject rogoStage;
    public VolumeActiv volumeActiv;

    private void Start()
    {

    }

    private void Update()
    {
        if(volumeActiv.IsVolume)
        {
            rogoStage.SetActive(false);
        }
        else if(!volumeActiv.IsVolume)
        {
            rogoStage.SetActive(true);
        }
    }
}
