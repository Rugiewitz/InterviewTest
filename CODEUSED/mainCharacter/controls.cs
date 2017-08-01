using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {
     Animator moveAnimation;
     public Transform cam;
     //public GameObject textZone;
     public GameObject textManager;
     public GameObject SpaceBar;
     public float speed = 1.75f;
     public bool cutscene1 = false;
     public bool cutscene2 = false;
     private bool disabled1, disabled2;

     private bool finishedCut=false;

     void Start() {
          moveAnimation = GetComponent<Animator>();
     }

     void Update() {
          if (!cutscene1 && !cutscene2) {
               Moving();
          }
          disabled1 = textManager.GetComponent<DboxScript>().disabled1;
          disabled2 = textManager.GetComponent<DboxScript>().disabled1;
     }

     void Moving() {
          if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A)) {
               moveAnimation.SetBool("right", false);
               moveAnimation.SetBool("move", true);
               transform.Translate(Vector2.left * speed * Time.deltaTime);

          }else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
               moveAnimation.SetBool("right", true);
               moveAnimation.SetBool("move", true);
               transform.Translate(Vector2.right * speed * Time.deltaTime);
               if (transform.position.x >= cam.position.x) {
                    cam.Translate(Vector2.right * speed * Time.deltaTime);
               }
          }
          else {
               moveAnimation.SetBool("move", false);
          }
     }

     private void OnTriggerStay2D(Collider2D other) {
          if (cutscene1 == false && cutscene2 == false) {
               if (other.name == "NPCPolice" && disabled1!=true) {
                    if (!finishedCut) {
                         SpaceBar.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.Z)) {
                         cutscene1 = true;
                         SpaceBar.SetActive(false);
                         textManager.SetActive(true);
                         textManager.GetComponent<DboxScript>().loadCutscene1();
}
               }
              /* else if ((other.name == "Mafia" || other.name == "Girl" || other.name == "Dead") && disabled2 != true) {
                    SpaceBar.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Z)) {
                         cutscene2 = true;
                         SpaceBar.SetActive(false);
                         textManager.SetActive(true);
                    }
               }*/
          }

     }

     public void EndCutScene() {
          cutscene1 = false;
          finishedCut = true;
          textManager.SetActive(false);
     }
}
