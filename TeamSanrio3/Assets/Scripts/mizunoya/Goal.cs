using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Key key;

    [SerializeField] private GameObject textUI;

    private bool isGoal = false;

    public bool IsGoal
    {
        get => isGoal;
        set => isGoal = value;
    }

    private void Start()
    {
        textUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !key.IsKey)
        {
            textUI.SetActive(true);
        }

        if (other.tag == "Player" && key.IsKey)
        {
            isGoal = true;
            SoundManager.Instance.PlaySeByName("ゴールしたとき");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            textUI.SetActive(false);
        }
    }
}
