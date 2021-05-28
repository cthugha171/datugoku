using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimeCon : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rb;
    PlayerCon playercon;
    //private SoundManager soundManager;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        playercon = gameObject.GetComponent<PlayerCon>();
        animator = GetComponent<Animator>();
        //soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (rb.velocity.magnitude > 0.1f&&playercon.ground == true)
        {
            animator.SetFloat("Playerspeed", rb.velocity.magnitude);
            if (time > 0.5f)
            {
                SoundManager.Instance.PlaySeByName("足音");
                time = 0;
            }
        }
        else
        {
            animator.SetFloat("Playerspeed", 0f);
        }

        if(playercon.chainanime == true)
        {
            animator.SetBool("HandFlag", true);
        }
        else
        {
            animator.SetBool("HandFlag",false);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(playercon.IsDeadFlag == true)
        {
            animator.SetTrigger("DeadTriger");
        }
    }
}
