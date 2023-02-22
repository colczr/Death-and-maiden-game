using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class restart : MonoBehaviour {

   void Update() {
     if(Input.GetKeyDown("x")){
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
     }
   }

}
