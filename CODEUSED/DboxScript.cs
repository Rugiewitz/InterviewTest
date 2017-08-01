using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DboxScript : MonoBehaviour {

     public GameObject Dbox;
     public Text Name;
     public Text textInfo;
     public Text pressContinue;
     private bool cut1 = false, cut2 = false;
     public bool disabled1 = false, disabled2=false;
     public bool dialogActive=false;
     private int x = 0;
     public struct textSpeak {
          public string name;
          public Color colorText;
          public string textInformation;
     };
     public GameObject mainCharacter;

     List<textSpeak> cutscene1 = new List<textSpeak>();

     void Update() {
          if (cut1 && !disabled1) {
               showName(cutscene1[x].name);
               showText(cutscene1[x].textInformation);
               changeColor(cutscene1[x].colorText);
               if (Input.GetKeyDown(KeyCode.Space)) {
                    x += 1;
               }
               if (x >= cutscene1.Count) {
                    cut1 = false;
                    disabled1 = false;
                    mainCharacter.GetComponent<controls>().EndCutScene();
               }
          }
     }
     
     public void loadCutscene1() {
          cutscene1.Add(new textSpeak {
               name = "Police:",
               colorText = Color.blue,
               textInformation = "Hello sir, sorry to call you at this time. You were the only one avilable to help me with this crime. How are you feeling?"
          });
          cutscene1.Add(new textSpeak {
               name = "P.I Dick:",
               colorText = Color.green,
               textInformation = "1.Pretty Good \n 2.Pretty Bad \n 3.I'm in a Game"
          });
          cutscene1.Add(new textSpeak {
               name = "P.I Dick:",
               colorText = Color.green,
               textInformation = "As an investigator, I tend to stay up this late. So pretty good!"
          });
          cutscene1.Add(new textSpeak {
               name = "P.I Dick:",
               colorText = Color.green,
               textInformation = "Who the hell calls someone 4 in the morning? So pretty bad."
          });
          cutscene1.Add(new textSpeak {
               name = "P.I Dick:",
               colorText = Color.green,
               textInformation = "I passed by the same resturant 14 times on my way here, an invisble wall is preventing me from going back home, and every time I stand still a few seconds I scratch my head. I'm in a game, right?"
          });
          cutscene1.Add(new textSpeak {
               name = "Police:",
               colorText = Color.blue,
               textInformation = "Good to hear. You'll be the top person in the force in no time!"
          });
          cutscene1.Add(new textSpeak {
               name = "Police:",
               colorText = Color.blue,
               textInformation = "Rookies like you need to learn that this is what it takes to be the best."
          });
          cutscene1.Add(new textSpeak {
               name = "Police:",
               colorText = Color.blue,
               textInformation = "Actually the resturant is dominating the city, the wall is all in your mind and I'm pretty sure you just have OCD. Guess being up this late is messing with your mind."
          });

          cutscene1.Add(new textSpeak {
               name = "Police:",
               colorText = Color.blue,
               textInformation = "Anyway, someone was shot. I pinned it down to one of these two, go do your thing."
          });
          cut1 = true;
     }

     

     public void showText(string dialouge) {
          textInfo.text = dialouge;
     }
     public void showName(string name) {
          Name.text = name;
     }
     public void changeColor(Color colorText) {
          textInfo.color =colorText ;
          Name.color = colorText;
     }
     public void changeContinue(string words) {

     }
}
