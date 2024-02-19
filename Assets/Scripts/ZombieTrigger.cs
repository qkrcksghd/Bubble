using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Zombie>().targetTransform = null;
            Debug.Log("닿음");
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);
            other.GetComponent<Player>().HP -= 2;
        }
    }
}
