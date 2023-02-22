using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class death : MonoBehaviour
{
    public GameObject obj;
    public AudioClip background;
    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    IEnumerator FadeOutStop(AudioSource audioSource, float FadeTime, AudioClip clip)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0.01f)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            Debug.Log("asdf");
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 0;
        audioSource.clip = clip;
        audioSource.Play();
        StartCoroutine(AudioFade.FadeIn(audioSource, 0.1f));

    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other){
      if (other.tag == "Player"){
        AudioSource bg;
        bg = GameObject.Find("bg").GetComponent<AudioSource>();
        StartCoroutine(FadeOutStop(bg, 1f, background));
        StartCoroutine(AudioFade.FadeOut(GameObject.Find("musictrigger").GetComponent<AudioSource>(), 1f));
        obj.SetActive(true);
        GameObject.Find("deadimg").GetComponent<RawImage>().CrossFadeAlpha(0, 0f, false);
        GameObject.Find("deadimg").GetComponent<RawImage>().CrossFadeAlpha(0.9f, 1.0f, false);
        GameObject.Find("player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        GameObject.Find("player").GetComponent<RigidbodyFirstPersonController>().enabled = false;
      }
    }
}
