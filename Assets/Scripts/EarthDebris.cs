using UnityEngine;
using System.Collections;

public class EarthDebris : MonoBehaviour {
	public float sanityBoost;
	public float materialsMod;
	public string pickupText;
	public string useText;
	public string key;
	public float commonality;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter (Collider collider) {
		Inventory.instance.AddDebris(this);
		this.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
