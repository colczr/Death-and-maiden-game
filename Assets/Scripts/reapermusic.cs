using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reapermusic : MonoBehaviour
{
    public bool musicOn;
    public AudioSource audio;
    public bool outYet;
    public AudioSource bg;
    // Start is called before the first frame update
    void Start(){
      audio = this.gameObject.GetComponent<AudioSource>();
      audio.enabled = false;
      bg = GameObject.Find("bg").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
      if (other.tag == "Player"){
        audio.enabled = true;
        audio.mute = false;
        StopCoroutine(AudioFade.FadeOut(audio, 1f));
        StartCoroutine(AudioFade.FadeIn(audio, 0.3f));
        StopCoroutine(AudioFade.FadeIn(bg, 0.3f));
        StartCoroutine(AudioFade.FadeOut(bg,1f));
      }
    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Player"){
        audio.mute = false;
      }
    }

    void OnTriggerExit(Collider other){
      if (other.tag == "Player"){
        StopCoroutine(AudioFade.FadeIn(audio, 0.3f));
        StartCoroutine(AudioFade.FadeOut(audio, 1f));
        StopCoroutine(AudioFade.FadeOut(bg, 1f));
        StartCoroutine(AudioFade.FadeIn(bg,0.3f));
      }
    }
}
