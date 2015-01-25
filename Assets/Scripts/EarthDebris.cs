using UnityEngine;
using System.Collections;

public class EarthDebris : MonoBehaviour {
	public float sanityBoost;
	public float materialsMod;
	public string pickupText;
	public string useText;
	public string key;
	public float commonality;
	public Vector3 lerpStart;
	public Vector3 lerpEnd;
	public float lerpConstant;
	public float startTime;
	public float journeyLength;
	public float speed;
	
		
	void OnTriggerEnter (Collider collider) {
		Inventory.instance.AddDebris(this);		
	}
	
}
