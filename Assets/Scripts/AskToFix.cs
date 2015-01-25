using UnityEngine;
using System.Collections;

public class AskToFix : MonoBehaviour {

	public float rad;
	public float sanFixCost;
	public float matFixCost;
	public bool hasMats;
	
	public void GrabPlayer (Vector3 center){
		Collider[] activeArea = Physics.OverlapSphere(center, rad);
		for (int i = 0; i < activeArea.Length; i++){
			if(activeArea[i].gameObject.tag == "Player") {
				/*present fix screen
				  if they press yes:*/
					if(hasMats){SendMessage("FixUp"); this.DamageSanity(activeArea[i].gameObject);}
					else {/*throw lack of materials message*/}
			}
		}
	}

	private void DamageSanity (GameObject Player) {
		Player.GetComponent<PlayerManager>().DecInsanity(this.sanFixCost);
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
