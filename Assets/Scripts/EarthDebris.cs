using UnityEngine;
using System.Collections;

public class EarthDebris : MonoBehaviour {
	public float sanityBoost;
	public float materialsMod;
	public string pickupText;
	public string useText;
	public string key;
	public float commonality;	
	
		
	void OnTriggerEnter (Collider collider) {
		rigidbody.isKinematic=true;
		if(collider.gameObject.tag == "Player"){
			Inventory.instance.AddDebris(this);		
		}
	}
	
}
