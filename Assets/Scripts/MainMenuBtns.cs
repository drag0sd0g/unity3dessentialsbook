using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class MainMenuBtns : MonoBehaviour {
	
	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rolloverTexture;
	public AudioClip beep;
	public bool quitButton = false;
	
	// hover/rollover
	void OnMouseEnter(){
		guiTexture.texture = rolloverTexture;
	}
	
	// move cursor away from
	void OnMouseExit(){
		guiTexture.texture = normalTexture;
	}
	
	//coroutine used only to make sure that the sound is played before loading the level
	IEnumerator OnMouseUp(){
		audio.PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);	
		if(quitButton){			
			Application.Quit();
			Debug.Log("this part works");
		} else {
			Application.LoadLevel(levelToLoad);
		}
	}
}
