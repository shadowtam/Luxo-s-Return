using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {
    
	public Camera mCam;
	void FaceMouse() {
		
		Ray cameraRay = mCam.ScreenPointToRay(Input.mousePosition);
		Plane gPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;
		
		if(gPlane.Raycast(cameraRay, out rayLength)) {
			Vector3 lookHere = cameraRay.GetPoint(rayLength);
			transform.LookAt(new Vector3(lookHere.x, transform.position.y, lookHere.z));
		}
		
		
	}
	// Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        FaceMouse();
    }
}
