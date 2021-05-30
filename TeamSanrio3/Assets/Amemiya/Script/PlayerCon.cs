using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public GameObject chain;
    ChainCon chaincon;
    public Vector3 prev;
    public Vector3 angles;
    public bool jump = false;
    public bool ground = false;
    public bool tenzyohit = false;
    public bool chainanime = false;
    public bool rotaz = false;
    public bool goal = false;
    [SerializeField] private bool isDeadFlag;
    public Rigidbody rb;
    int speed;
    public bool playcon = false;
    FixedJoint fx;

    public bool IsDeadFlag
    {
        get => isDeadFlag;
        set => isDeadFlag = value;
    }
    void Start()
    {
        chaincon = chain.GetComponent<ChainCon>();
        fx = gameObject.GetComponent<FixedJoint>();
    }
    void Update()
    {
        Debug.Log(rb.velocity);
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        speed = 0;
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") > 0)
        {
            playcon = true;
        }
        if (chaincon.chain == false && chaincon.click == false&&isDeadFlag == false && jump == false)
        {
            Vector3 scale = transform.localScale;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.velocity += new Vector3(-0.2f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.velocity += new Vector3(0.2f, 0.0f);
            }
            if (playcon == true)
            {
                rb.velocity += new Vector3(0.4f * hori, 0.0f);
                
            }
            if(hori == 1||hori == -1)
            {
                scale.x = hori;
            }
            if (playcon == true && jump == false)
            {
                rb.velocity += new Vector3(0.0f, 3.0f * vert);
                jump = true;
            }
            gameObject.transform.localScale = scale;
            chainanime = false;
        }
        if (chaincon.chain == false && chaincon.click == false && isDeadFlag == false)
        {
            Vector3 scale = transform.localScale;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                scale.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                scale.x = 1;
            }
            gameObject.transform.localScale = scale;
        }
        if (chaincon.chain == true)
        {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb.velocity += new Vector3(-0.3f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb.velocity += new Vector3(0.3f, 0.0f);
            }
            if (playcon == true)
            {
                rb.velocity += new Vector3(0.6f * hori, 0.0f);
            }
            if (playcon == true && jump == false)
            {
                rb.velocity += new Vector3(0.0f, 12.0f * vert);
                jump = true;
            }

            rb.constraints = RigidbodyConstraints.None;
            chainanime = true;
            ground = false;

        }
        if (chaincon.click && ground == true)
        {
            float x = 0.0f;
            float y = rb.velocity.y;
            float z = 0.0f;
            rb.velocity = new Vector3(x, y, z);

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && jump == false || Input.GetKeyDown(KeyCode.W) && jump == false || Input.GetAxis("Vertical") > 0 && jump == false)
        {
            rb.velocity += new Vector3(0.0f, 12.0f);
            jump = true;
        }
        if (!chaincon.chain)
        {
            angles = transform.localEulerAngles;
            angles.x = 0.0f;
            angles.y = 0.0f;
            transform.localEulerAngles = angles;
        }
        if(jump == true&&chaincon.chain == false)
        {
            Invoke("RBFreez", 0.1f);
        }
        if (IsDeadFlag == true)
        {
            rb.velocity = Vector3.zero;
        }
        if (jump == true && rotaz == false && chaincon.chain != true)
        {

            angles = transform.localEulerAngles;
            if (angles.z > 180)
            {
                angles.z += 0.5f;
                transform.localEulerAngles = angles;
            }
            else
            {
                angles.z -= 0.5f;
                transform.localEulerAngles = angles;
            }

        }
        //var pos = transform.localPosition;
        //pos.z = -0.05f;
        //transform.localPosition = pos;
        //angles = transform.localEulerAngles;
    }
    void RBFreez()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            goal = true;
            rb.velocity = Vector3.zero;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (tenzyohit == false)
        {
            if (collision.gameObject.tag == "Ground" && chaincon.chain == false)
            {
                jump = false;
                ground = true;
                rotaz = false;
                angles = transform.localEulerAngles;
                angles.z = 0.0f;
                transform.localEulerAngles = angles;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            }
        }
        if (collision.gameObject.name == "tenzyo(Clone)")
        {
            tenzyohit = true;
            //rb.constraints = RigidbodyConstraints.None;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && chaincon.chain == false)
        {
            jump = true;
            ground = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
            angles = transform.localEulerAngles;
            angles.x = 0.0f;
            angles.y = 0.0f;
            angles.z = 0.0f;
            transform.localEulerAngles = angles;
        }
        if (collision.gameObject.name == "tenzyo(Clone)")
        {
            tenzyohit = false;
        }
    }
}

