using UnityEngine;
using System.Collections;

public class SafeZoneGenerator : MonoBehaviour {
	public float rad;
	
	void EnactSafeZone (Vector3 center, float rad){
		Collider[] safeZone = Physics.OverlapSphere(center, rad);
		for (int i = 0; i < safeZone.Length; i++){
			if(safeZone[i].gameObject.tag == "Player") {
				safeZone[i].GetComponent<PlayerManager>().inSafeZone = true;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		PowerGenerator generator = this.gameObject.GetComponent<PowerGenerator>();
		if(generator != null && generator.failed){
			return;
		}
		else if (generator != null && !generator.failed){
			EnactSafeZone(this.gameObject.transform.position, rad);
		}
		else if (this.gameObject.GetComponent<PowerNode>().failed){
			return;	
		}
		else{
			EnactSafeZone (this.gameObject.transform.position, rad);
		}
	}		
}
