using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	
	private bool doorIsOpen = false;
	private float doorTimer = 0.0f;
	
	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;
	
	void Start(){
		doorTimer = 0.0f;
	}

	void Update () {
		if(doorIsOpen){
			doorTimer += Time.deltaTime;
			
			if(doorTimer > doorOpenTime){
				ShutDoor();
				doorTimer = 0.0f;
			}
		}
	
	}
	
	void OpenDoor(){
		if(!doorIsOpen){
			UpdateDoor(doorOpenSound, true, "dooropen");
		}
	}
	
	void ShutDoor(){
		UpdateDoor(doorShutSound, false, "doorshut");
	}
	
	void UpdateDoor(AudioClip aClip, bool openCheck, string animName){
		doorIsOpen = openCheck;
		audio.PlayOneShot(aClip);
		transform.parent.animation.Play(animName);
	}
}
