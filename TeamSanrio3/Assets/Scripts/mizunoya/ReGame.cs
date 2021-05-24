using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReGame : MonoBehaviour
{
    private Pause pause;

    public void ReGames()
    {
        pause = FindObjectOfType<Pause>();

        pause.FalseActive();
        Time.timeScale = 1f;
        pause.isPause = false;
    }
}
