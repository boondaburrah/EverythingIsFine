using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {
	public Dictionary<string, EarthDebris> foundObjects;
	public int debrisCapacity;
	public TextAsset debrisNotice;
	public Dictionary<string, RawMaterials> craftingSupplies;
	public static int craftCapacity;
	public TextAsset craftNotice;
	public int moonRocks;	
	public static int moonCapacity;
	public TextAsset moonNotice;

	// Use this for initialization
	void Start () {
		foundObjects = new Dictionary<string, EarthDebris>();
		craftingSupplies = new Dictionary<string, RawMaterials>();	
	}

//Add Functions
	public void AddDebris (EarthDebris found) {
		if(!IsDebrisFull()){
			foundObjects.Add(found.key, found);
			//debrisNotice = debrisSuccess
		} else {
			//debrisNotice = debrisFail
		}
	}

	public void AddCraft (RawMaterials newMat) {
		if(!IsCraftFull()){
			craftingSupplies.Add(newMat.key, newMat);
			//debrisNotice = debrisSuccess
		} else {
			//debrisNotice = debrisFail
		}
	}
	public void addRocks () {
		if(!IsMoonFull()) {
			moonRocks++;
			//success text
		}
		else{
			//failtext
		}
	}

//Subtract Functions
	public void DecDebris (string key) {
		foundObjects.Remove(key);
		//successtext
	}
	public void DecCraft (string key) {
		craftingSupplies.Remove(key);
		//successtext
	}
	public void DecMoon () {
		moonRocks --;
		//successtext
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
