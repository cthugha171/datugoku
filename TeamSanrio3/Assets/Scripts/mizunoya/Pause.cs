using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPause = false;
    [SerializeField] private GameObject PauseUIPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        PauseUIPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("START"))
        {
            if(!isPause)
            {
                TrueActive();
                Time.timeScale = 0f;
                isPause = true;
            }
            else if(isPause)
            {
                FalseActive();
                Time.timeScale = 1f;
                isPause = false;
            }
        }
    }

    public bool GetPause()
    {
        return isPause;
    }

    public void TrueActive()
    {
        PauseUIPrefab.SetActive(true);
    }

    public void FalseActive()
    {
        PauseUIPrefab.SetActive(false);
    }
}
