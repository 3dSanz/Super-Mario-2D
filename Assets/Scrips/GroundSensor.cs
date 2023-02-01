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
        if(other.gameObject.layer==3){
         isGrounded = true;     
         controller.anim.SetBool("IsJumping", false);
        } else if(other.gameObject.layer==6)
        {
            Debug.Log("Goomba muerto");
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "DeadZone"){
            Debug.Log("Estoy muerto");
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
          isGrounded = true;     
          controller.anim.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
         isGrounded = false;
         controller.anim.SetBool("IsJumping", true);     
        }
    }
}
