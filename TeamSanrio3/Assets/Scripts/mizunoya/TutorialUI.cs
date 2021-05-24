using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    private bool isActiv = false;

    [SerializeField] private GameObject TutorialPrafab;

    private void Start()
    {
        TutorialPrafab.SetActive(false);
    }

    public void TrueActive()
    {
        TutorialPrafab.SetActive(true);
    }

    public void FalseActive()
    {
        TutorialPrafab.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TrueActive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FalseActive();
        }
    }
}
