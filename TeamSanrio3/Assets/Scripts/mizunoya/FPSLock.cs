using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    [SerializeField] private int FPS = 60;

    private void Awake()
    {
        Application.targetFrameRate = FPS;
    }
}
