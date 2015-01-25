using UnityEngine;
using System.Collections;

public class GateTravel : MonoBehaviour {
	int thisLevel;
	int otherLevel;
	// Use this for initialization
	void Start () {
		thisLevel = Application.loadedLevel;
		if (thisLevel == 0){otherLevel =1;}
		else {otherLevel = 0;}
	
	}
	void OnTriggerEnter (Collider collider) {
		Application.LoadLevel(otherLevel);
		
	}
}
