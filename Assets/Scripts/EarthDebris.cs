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
		Inventory.instance.AddDebris(this);		
	}
	
}
