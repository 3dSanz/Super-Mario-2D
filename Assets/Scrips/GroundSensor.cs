using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;

    private void Awake() {
        controller = GetComponentInParent<PlayerController>();    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
       isGrounded = true;     
       controller.anim.SetBool("isJumping", false);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        isGrounded = true;
        controller.anim.SetBool("isJumping", false);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        isGrounded = false;
    }
}
