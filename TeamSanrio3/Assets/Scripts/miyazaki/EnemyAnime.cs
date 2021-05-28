using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnime : MonoBehaviour
{
    EnemyMove Emove;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Emove = FindObjectOfType<EnemyMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Emove.Anime == true)
        {
            animator.SetFloat("walkspeed", 1.0f);;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            animator.SetBool("found", true);

        }
    }
}
