using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	void Start () {
		Rect currentResolution = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		guiTexture.pixelInset = currentResolution;
	}
	
	
}
