using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {
	
	public float rotationSpeed = 100.0f;

	void Update () {
		transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));	
	}
	
	void OnTriggerEnter (Collider collider) {
		if(collider.gameObject.name == "First Person Controller"){
			collider.gameObject.SendMessage("CellPickup");
			Destroy (gameObject);
		}
	}
	
}
