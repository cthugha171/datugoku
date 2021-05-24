using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Goal goal;
    
    private void Start()
    {
        goal = FindObjectOfType<Goal>();
    }
    
    private void Update()
    {
        if(goal.IsGoal)
        {
            Time.timeScale = 0f;
        }
    }
}
