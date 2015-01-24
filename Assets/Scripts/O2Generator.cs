using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class O2Generator : MonoBehaviour {
	public bool hasPower;
	public bool isFail;
	public PowerGenerator parent;
	public List<O2Node> children;
	

	// Use this for initialization
	void Start () {
	
	}
	public bool CanActivate () {
		bool retVal = false;
		return retVal;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
