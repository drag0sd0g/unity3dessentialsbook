using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	private GameObject currentDoor;

	void Update () {
		RaycastHit hit;
		
		if(Physics.Raycast(transform.position, transform.forward, out hit, 3)){ // 3 == length of the ray. in this case 3 meters
			if(hit.collider.gameObject.tag == "playerDoor"){
				currentDoor = hit.collider.gameObject;
				currentDoor.SendMessage("OpenDoor");
			}
		}
	}	
	
	
}
