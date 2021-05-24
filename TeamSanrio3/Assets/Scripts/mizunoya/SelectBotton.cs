using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBotton : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private int firstSelectButton;

    private void Start()
    {
        buttons[firstSelectButton].Select();
    }
}
