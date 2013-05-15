using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {
	
	public AudioClip lockedSound;
	public Light doorLight;
	public GUIText textHints;
	
	void OnTriggerEnter (Collider collider) {
		if(collider.gameObject.name == "First Person Controller"){
			if(Inventory.charge == 4){
				transform.FindChild("door").SendMessage("OpenDoor");
				if(GameObject.Find("PowerGUI")){
					Destroy(GameObject.Find("PowerGUI"));
					doorLight.color = Color.green;
				}
			} else if(Inventory.charge > 0 && Inventory.charge < 4){
				textHints.SendMessage("ShowHint", "This door needs full charging. Find 4 power cells to open it");
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
			} else {
				transform.FindChild("door").audio.PlayOneShot(lockedSound);
				collider.gameObject.SendMessage("HUDon");
				textHints.SendMessage("ShowHint", "This door seems locked.. maybe dat generation needs power :3");
			}
		}
	}

}
