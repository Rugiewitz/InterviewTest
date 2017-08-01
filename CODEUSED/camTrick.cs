using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTrick : MonoBehaviour {

     public Transform[] backgrounds;
     public Transform point1, point2,point3;
     private float[] parallaxScales;
     public float smoothing=10;
     //private bool hit = false;
     private double backgroundreset = -1.0;
     private Vector3 previousCameraPositions;


	void Start () {
          previousCameraPositions = transform.position;
          parallaxScales = new float[backgrounds.Length];

          for(int i = 0; i<parallaxScales.Length; i++) {
               parallaxScales[i] = backgrounds[i].position.z * -1;
          }
	}

     void LateUpdate() {
          for (int i = 0;i<backgrounds.Length;i++) {
               Vector3 parallax = (previousCameraPositions - transform.position) * (parallaxScales[i]/smoothing);
               backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);
          }
          if (point1.position.x > point2.position.x) {
               backgrounds[0].position += new Vector3(15, 0, 0);
          }
          if (point1.position.x > point3.position.x) {
               backgrounds[1].position += new Vector3(15, 0, 0);
          }
          previousCameraPositions = transform.position;
     }
}
