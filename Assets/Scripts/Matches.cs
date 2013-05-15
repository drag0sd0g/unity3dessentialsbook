using UnityEngine;
using System.Collections;

public class Matches : MonoBehaviour {

	
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.name == "First Person Controller"){
			col.gameObject.SendMessage("MatchPickup");
			Destroy(gameObject);
		}
	}

}
