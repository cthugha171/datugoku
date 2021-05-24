using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundElect : MonoBehaviour
{
    
    private SoundManager soundManager;
    [SerializeField] private string soundName;
    [SerializeField] private Renderer thisObj;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(soundName==null)
        {
            return;
        }
        if(thisObj.isVisible)
        {
            soundManager.PlaySeByName(soundName);
        }
    }
}
