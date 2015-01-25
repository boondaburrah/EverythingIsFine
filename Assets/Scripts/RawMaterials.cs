using UnityEngine;
using System.Collections;

public class RawMaterials : MonoBehaviour {
	public string key;
	public float fixMod;
	public string pickupText;
	public string useText;

	void OnTriggerEnter (Collider collider) {
		Inventory.instance.AddCraft(this);		
	}
}
