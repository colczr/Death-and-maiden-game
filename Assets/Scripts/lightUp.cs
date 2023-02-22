using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightUp : MonoBehaviour
{
    public int lightCount;
    private float length;
    public bool effect;
    public GameObject reaper;

    // Start is called before the first frame update
    void Start()
    {
      lightCount = 1;
      length = 0;
      effect = false;
    }

    // Update is called once per frame
    void Update()
    {
      Light light = GameObject.Find("player").GetComponent<Light>();
      if (lightCount > 0){
        if (Input.GetKeyDown ("r")){
          StartCoroutine(intensityVar(light, 3, true));
          lightCount--;
          effect = true;
          reaper.GetComponent<monster2>().enabled = false;
        }
      }
      if (effect){
        length += Time.deltaTime;
        Debug.Log("len");
        if (length > 9){
          effect = false;
          length = 0;
          StartCoroutine(intensityVar(light, 0, false));
        }
      }
    }
    IEnumerator intensityVar(Light light, int intensity, bool direction)
    {
        if (direction){
          while (light.intensity < intensity)
          {
              light.intensity += Time.deltaTime*5;
              Debug.Log("intense");
              yield return null;
          }
        } else {
          while (light.intensity > 0)
          {
              light.intensity -= Time.deltaTime*5;
              Debug.Log("intense");
              yield return null;
          }
          reaper.GetComponent<monster2>().enabled = true;
        }

    }
}
