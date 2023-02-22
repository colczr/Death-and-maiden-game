using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterAI : MonoBehaviour {

    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxDistance;
    public bool chase;
    public GameObject go;

    // Use this for initialization
    void Start () {
        go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        chase = false;
        maxDistance = 3;
    }

    //Update is called once per frame
    void Update () {
      // if (chase == true){
        Debug.DrawLine(target.position,transform.position,Color.yellow);
        //look at Target
        transform.LookAt(target);
      // }
      if (Vector3.Distance(target.position,transform.position) > maxDistance){
        if (Vector3.Distance(target.position,transform.position) > 50){
          moveSpeed = 20;
        } else {
          moveSpeed =10;
        }
        transform.position += transform.forward * moveSpeed *Time.deltaTime;

      }
    }

    // void Update(){
    //   agent.destination = transform.position;
    // }


  public void OnTriggerEnter(Collider other){


  }
}
