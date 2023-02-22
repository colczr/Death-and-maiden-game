using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class showMemory : MonoBehaviour
{
    public bool isImgOn;
    public RawImage img;
    public GameObject obj;
    public RigidbodyFirstPersonController controller;
    public GameObject player;
    public bool entered;
    public char letter;
    public int order;
    public AudioClip background;
    public Material sky;
    public Color color;
    public bool final;
    public GameObject reap2;
    public GameObject dead;

    void Start () {
        letter = this.name[this.name.Length - 1];
        order = (int)(letter - '0');
        order++;
        player = GameObject.Find("player");
        obj = GameObject.Find(this.name+"_img");
        img = obj.GetComponent<RawImage>();
        img.enabled = false;
        isImgOn = false;
        controller = player.GetComponent<RigidbodyFirstPersonController>();
        entered = false;
        if(this.name == "memory_1"){
          this.gameObject.GetComponent<Light>().enabled = true;
          GameObject.Find("memory_"+order).GetComponent<Light>().enabled = false;
        } else {
          if(GameObject.Find("memory_"+order) != null){
            GameObject.Find("memory_"+order).GetComponent<Light>().enabled = false;
          }
        }
        color = new Color32(205,125,132,0);
        GameObject.Find("preending").GetComponent<RawImage>().enabled = false;
        final = false;
        GameObject.Find("ending").GetComponent<RawImage>().enabled = false;
        GameObject.Find("white").GetComponent<Image>().enabled = false;
    }

    void OnTriggerEnter(Collider other){
      Debug.Log("asdfasdfasdf");
      if (other.tag == "Player" && this.GetComponent<Light>().enabled == true){
      // if (other.tag == "Player"){
        GameObject.Find("player").GetComponent<lightUp>().lightCount += 1;
        Debug.Log("1");
        img.enabled = true;
        img.CrossFadeAlpha(0, 0f, false);
        img.CrossFadeAlpha(1, 1.0f, false);
        isImgOn = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        reap2.GetComponent<monster2>().enabled = false;
        controller.enabled = false;
        entered = true;
        if(GameObject.Find("memory_"+order) != null){
          GameObject.Find("memory_"+order).GetComponent<Light>().enabled = true;
        }
        AudioSource bg;
        bg = GameObject.Find("bg").GetComponent<AudioSource>();
        StartCoroutine(FadeOutStop(bg, 1f, background));
        // bg.clip = background;
        // bg.Play();
        if (this.name == "memory_5"){
          final = true;
        }
      }

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

    void Update (){
      if(entered == true){
        if (Input.GetKeyDown ("x")){
          if (this.name == "memory_1"){
            reap2.SetActive(true);
            dead.SetActive(true);
          }
          if (this.name != "memory_5"){
            Debug.Log("2");
            img.CrossFadeAlpha(0, 1.0f, false);
            img.enabled = false;
            isImgOn = false;
            controller.enabled = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            reap2.GetComponent<monster2>().enabled = true;
            Destroy(this.gameObject.GetComponent<Light>());
            Destroy(this);

          } else {
            img.CrossFadeAlpha(0, 1.0f, false);
            img.enabled = false;
            RenderSettings.ambientLight = color;
            RenderSettings.skybox = sky;
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("finalcamera").GetComponent<Camera>().enabled = true;
            Destroy(reap2);
            StartCoroutine(CameraUp(GameObject.Find("finalcamera")));
          }
        }
      }

    }

    IEnumerator CameraUp(GameObject camera)
    {
        while (camera.transform.position.y < 140)
        {
            camera.transform.Translate(Vector3.up*5*Time.deltaTime);
            yield return null;
        }
        GameObject.Find("preending").GetComponent<RawImage>().enabled = true;
        GameObject.Find("preending").GetComponent<RawImage>().CrossFadeAlpha(0, 0f, false);
        GameObject.Find("preending").GetComponent<RawImage>().CrossFadeAlpha(1, 1.0f, false);
        Debug.Log("camUp");
        if(final == true && Input.GetKeyDown("x")){
            GameObject.Find("preending").GetComponent<RawImage>().CrossFadeAlpha(0, 1.0f, false);
            GameObject.Find("white").GetComponent<Image>().enabled = true;
            GameObject.Find("ending").GetComponent<RawImage>().enabled = true;
            GameObject.Find("ending").GetComponent<RawImage>().CrossFadeAlpha(0, 0f, false);
            GameObject.Find("ending").GetComponent<RawImage>().CrossFadeAlpha(1, 1.0f, false);
            final = false;
            Debug.Log("d");

        }

    }


}
