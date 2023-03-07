using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;

    SFXManager sfxManager;
    SoundManager soundManager;

    private void Awake() {
        controller = GetComponentInParent<PlayerController>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
         isGrounded = true;     
         controller.anim.SetBool("IsJumping", false);
        } else if(other.gameObject.layer==6)
        {
            Debug.Log("Goomba muerto");
            sfxManager.GoombaDeath();
            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();
        }
        if(other.gameObject.tag == "DeadZone"){
            Debug.Log("Estoy muerto");
            sfxManager.MarioDeath();
            soundManager.StopBGM();
            SceneManager.LoadScene(2);
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
