using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteElectric : MonoBehaviour
{
    [SerializeField] private Sprite[] electric;
    [SerializeField] private float ChangeSpeed1 = 5;
    [SerializeField] private float ChangeSpeed2 = 10;
    [SerializeField] private SpriteRenderer render;

    bool returnFlag=false;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < electric.Length; i++)
        {
            Debug.Log("image is null:" + render == null);
            if (electric[i] == null)
            {
                Debug.Log("electric[" + i + "]:null");
                returnFlag = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        Draw();
    }

    private void Draw()
    {
        count++;
        
        if(count%ChangeSpeed1==0)
        {
            render.sprite = electric[1];
        }
        else if(count % ChangeSpeed2 == 0)
        {
            render.sprite = electric[0];
        }
    }
}
