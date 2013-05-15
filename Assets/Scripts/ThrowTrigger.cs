using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {
	
	public GUITexture crosshair;
	public GUIText textHints;
	
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "First Person Controller"){
			CoconutThrower.canThrow = true;
			crosshair.enabled = true;
			
			if(!CoconutWin.haveWon){
				textHints.SendMessage("ShowHint", "\n\n\n\n\nthere's a power cell on the right. i need to win to get it");
			}
			
		}
	}
	
	void OnTriggerExit(Collider collider){
		if(collider.gameObject.name == "First Person Controller"){
			CoconutThrower.canThrow = false;
			crosshair.enabled = false;
		}
	}
	
	
}
