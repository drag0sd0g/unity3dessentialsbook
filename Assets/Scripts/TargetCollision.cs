using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class TargetCollision : MonoBehaviour {
	
	private bool beenHit = false;
	private Animation targetRoot;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public float resetTime = 3.0f;
	
	
	void Start () {
		targetRoot = transform.parent.transform.parent.animation;
	}
	
	
	void OnCollisionEnter (Collision theObject) {
		if (!beenHit && theObject.gameObject.name == "coconut"){
			StartCoroutine("targetHit");
		}
	}
	
	IEnumerator targetHit(){
		UpdateTarget(hitSound, "down", true);		
		CoconutWin.targets++;		
		
		yield return new WaitForSeconds(resetTime);
		
		UpdateTarget(resetSound, "up", false);
		CoconutWin.targets--;
	}
	
	void UpdateTarget(AudioClip soundToPlay, string animationToplay, bool switchHitFlag){
		audio.PlayOneShot(soundToPlay);
		targetRoot.Play(animationToplay);
		beenHit = switchHitFlag;
	}
}
