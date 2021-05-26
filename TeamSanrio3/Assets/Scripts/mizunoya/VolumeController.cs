using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public enum VolumeType
    {
        MASTER,
        BGM,
        SE,
    }

    [SerializeField] private VolumeType volumeType = 0;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void OnValueChanged()
    {
        switch(volumeType)
        {
            case VolumeType.MASTER:
                SoundManager.Instance.Volume = slider.value;
                break;
            case VolumeType.BGM:
                SoundManager.Instance.BgmVolume = slider.value;
                break;
            case VolumeType.SE:
                SoundManager.Instance.SeVolume = slider.value;
                break;
        }
    }
}
