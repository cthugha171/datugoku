using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeActive : MonoBehaviour
{
    [SerializeField] private GameObject electric;
    [SerializeField] private float interval = 20;
    [SerializeField] private bool active=false;

    float count = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count+=Time.deltaTime;
        if(count>=interval)
        {
            active = !active;
            count = 0.0f;
        }
        electric.SetActive(active);
    }
}
