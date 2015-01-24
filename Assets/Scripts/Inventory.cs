using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {
	public List<EarthDebris> foundObjects;
	public int debrisCapacity;
	public TextAsset debrisNotice;
	public List<RawMaterials> craftingSupplies;
	public static int craftCapacity;
	public TextAsset craftNotice;
	public int moonRocks;	
	public static int moonCapacity;
	public TextAsset moonNotice;

	// Use this for initialization
	void Start () {
	
	}
	public void AddDebris (EarthDebris found) {
		if(!IsDebrisFull()){
			foundObjects.Add(found);
			//debrisNotice = debrisSuccess
		} else {
			//debrisNotice = debrisFail
		}
	}

	public void AddCraft (RawMaterials newMat) {
		if(!IsCraftFull()){
			craftingSupplies.Add(newMat);
			//debrisNotice = debrisSuccess
		} else {
			//debrisNotice = debrisFail
		}
	}

//Helper Functions
	//CountRetrievers
	int getDebCount () { return foundObjects.Count;}
	int getCraftCount () {return craftingSupplies.Count;}

	//Capacity Checkers
	bool IsDebrisFull () {
		if(foundObjects.Count == debrisCapacity) {return true;}
		else {return false;}
	}

	bool IsCraftFull () {
		if(craftingSupplies.Count == craftCapacity) {return true;}
		else {return false;}
	}

	bool IsMoonFull () {
		if (moonRocks == moonCapacity) {return true;}
		else {return false;}
	}
			
			
			
		
	
	// Update is called once per frame
	void Update () {
	
	}
}
