using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SFXManager sfxManager;
    // Start is called before the first frame update
    void Start()
    {
     boxCollider = GetComponent<BoxCollider2D>();
     sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    public void TocarBandera()
    {
        boxCollider.enabled = false;
        sfxManager.BanderaTocada();
    } 
}
