using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceGenerator : MonoBehaviour {
	
	public float resourceCount;
	private Vector3 spawnPos;
	public GameObject prefab;
	bool playerHere;
	bool noDebris;
	GameObject playerHolder;
	

	// Use this for initialization
	void Start () {
		resourceCount =0;	
		playerHere = false;
		noDebris = false;
	
	}
	public void DebrisIntake (EarthDebris debris){
		Debug.Log("intaking Debris");
		resourceCount += debris.materialsMod;
		PlayerManager.control.DecInsanity(debris.sanityBoost/2);	
		MatSpawner(debris.gameObject.name);
		Destroy(debris.gameObject);
	}
			
		
	public void MatSpawner (string name){
		GameObject newDrop;
		while(resourceCount > 0) {	
			spawnPos = transform.position;
			newDrop = Instantiate(prefab, spawnPos, transform.rotation) as GameObject;
			newDrop.GetComponent<RawMaterials>().key = "RawMaterialFrom" +name + resourceCount.ToString();
			newDrop.name= newDrop.GetComponent<RawMaterials>().key;
			if(newDrop != null) { Debug.Log("success!");}
			else{Debug.Log("Fail!");}
			resourceCount--;
		}		
	}
	
	void OnTriggerEnter (Collider player) {
		Debug.Log ("Triggered");
		playerHere = true;
		playerHolder = player.gameObject;	
			
	}
	void OnTriggerExit (Collider player) {
		playerHere = false;
	}
	bool HasDebris(GameObject player) {
		if (player.GetComponent<Inventory>().getDebCount() > 0){
			return true;
		}
		return false;
	}
			
	void OnGUI (){
		if(this.GetComponent<AskToFix>().failed) {
			return;
		}
		else if(playerHere) {
			GUI.Label (new Rect(300,300,200, 100), "Press \"return\" to convert debris");
			if(Input.GetKeyDown("return")){
				Debug.Log("got key");
				if(HasDebris(playerHolder)){
					DebrisIntake(playerHolder.GetComponent<Inventory>().GrabDebris());
				}
				else{
					Debug.Log ("no debris");
					noDebris = true;
					playerHere = false;
				}
			}
			else{
				Debug.Log ("didn't read key");
			}
		}
		else if (noDebris){
			GUI.Label (new Rect (300, 300, 200, 100), "I don't have anything to change!");
		}
	}
	// Update is called once per frame
	void Update () {
	
	
	}
}
