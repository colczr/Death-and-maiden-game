// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
//
// public class monster2 : MonoBehaviour
// {
//     NavMeshAgent agent;
//     public GameObject go;
//     // Start is called before the first frame update
//     void Start()
//     {
//       agent = GetComponent<NavMeshAgent>();
//       go = GameObject.FindGameObjectWithTag("Player");
//       agent.speed = 10;
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//       agent.destination = go.transform.position;
//       if(Vector3.Distance(go.transform.position,transform.position) > 100){
//         agent.speed = 30;
//       } else {
//         agent.speed = 12;
//       }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster2 : MonoBehaviour {

    public Transform target;
    public int moveSpeed;
    public int maxDistance;
    public GameObject go;

    // Use this for initialization
    void Start () {
        go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        maxDistance = 0;
    }

    //Update is called once per frame
    void Update () {
      // if (chase == true){
        Debug.DrawLine(target.position,transform.position,Color.yellow);
        //look at Target
        transform.LookAt(target);
      // }
      if (Vector3.Distance(target.position,transform.position) > maxDistance){
        if (Vector3.Distance(target.position,transform.position) > 80){
          moveSpeed = 20;
        } else {
          moveSpeed =13;
        }
        transform.position += transform.forward * moveSpeed *Time.deltaTime;

      }
    }

    // void Update(){
    //   agent.destination = transform.position;
    // }


}
