using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SFXManager sfxManager;
    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
     boxCollider = GetComponent<BoxCollider2D>();
     sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
     soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    public void TocarBandera()
    {
        boxCollider.enabled = false;
        sfxManager.BanderaTocada();
        soundManager.StopBGM();
    } 
}
