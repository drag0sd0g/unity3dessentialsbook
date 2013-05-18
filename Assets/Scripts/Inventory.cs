using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	public static int charge = 0;
	public AudioClip collectSound;
	
	//hud
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	
	//door entry generator
	public Texture2D[] meterCharge;
	public Renderer meter;
	
	//matches
	bool haveMatches = false;
	bool fireIsLit = false;
	public GUITexture matchGUIprefab;
	private GUITexture matchGUI;
	
	//hints
	public GUIText textHints;
	
	//win animation
	public GameObject winObj;
	
	void Start () {
		charge = 0;
	}
	
	void CellPickup(){
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		chargeHudGUI.texture = hudCharge[++charge];
		meter.material.mainTexture = meterCharge[charge];
		HUDon();
	}
	
	void HUDon(){
		if(!chargeHudGUI.enabled){
			chargeHudGUI.enabled = true;
		}
	}
	
	void MatchPickup(){
		haveMatches = true;
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		GUITexture matchHUD = Instantiate(matchGUIprefab, new Vector3(0.15f, 0.1f, 0), transform.rotation) as GUITexture;
		matchGUI = matchHUD;
	}
	
	void OnControllerColliderHit(ControllerColliderHit col){
		if(col.gameObject.name == "campfire"){
			if(haveMatches){
				LightFire(col.gameObject);
				fireIsLit = true;
			} else if (!fireIsLit) {
				textHints.SendMessage("ShowHint", "I could use this campfire to signal for help. Only if I could find matches to light it up");			
			}				
		}
	}
	
	void LightFire(GameObject campfire){
		ParticleEmitter[] emitters = campfire.GetComponentsInChildren<ParticleEmitter>();
		foreach(ParticleEmitter particleEmitter in emitters){
			particleEmitter.emit = true;
		}
		
		campfire.audio.Play();
		Destroy(matchGUI);
		haveMatches = false;
		winObj.SendMessage("GameOver");
	}

}
