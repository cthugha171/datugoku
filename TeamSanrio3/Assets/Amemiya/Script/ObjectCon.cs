using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCon : MonoBehaviour
{
    public GameObject chain;
    public GameObject player;
    ChainCon chaincon;
    // Start is called before the first frame update
    void Start()
    {
        chain = GameObject.FindWithTag("ChainObject");
        player = GameObject.FindGameObjectWithTag("Player");
        chaincon = chain.GetComponent<ChainCon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (chaincon.chain == false && chaincon.hitflag == false)
        {
            HingeJoint HJ = gameObject.GetComponent<HingeJoint>();
            HJ.connectedBody = null;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ChainObject"&&chaincon.hitflag == true&&chaincon.click == true)
        {
            //gameObject.AddComponent<HingeJoint>();
            HingeJoint HJ = gameObject.GetComponent<HingeJoint>();
            BoxCollider boxcol = chain.GetComponent<BoxCollider>();
            HJ.connectedBody = boxcol.attachedRigidbody;
        }
    }
}

