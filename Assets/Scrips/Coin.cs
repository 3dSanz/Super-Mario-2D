using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxCollider;
    Animator anim;
    SFXManager sfxManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    public void Pick()
    {
        anim.SetBool("Giro Moneda", false);
        boxCollider.enabled = false;
        Destroy(this.gameObject);
        sfxManager.MonedaCogida();
    } 
}
