using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip goombaDeath;
    public AudioClip marioDeath;
    public AudioClip monedaCogida;
    public AudioClip banderaTocada;

    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();

    }

    public void GoombaDeath() 
    {
         source.PlayOneShot(goombaDeath);
    }

    public void MarioDeath() 
    {
         source.PlayOneShot(marioDeath);
    }
    public void MonedaCogida() 
    {
         source.PlayOneShot(monedaCogida);
    }
        public void BanderaTocada() 
    {
         source.PlayOneShot(banderaTocada);
    }
}
