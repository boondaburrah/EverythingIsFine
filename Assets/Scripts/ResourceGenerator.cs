using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceGenerator : MonoBehaviour {
	public bool hasPower;
	public bool failed;
	public PowerGenerator parent;
	public float failRate;
	public float timeSinceRoll;
	public float failProb;
	public float rollTimeout;
	public PowerGenerator generator;
	public float resourceCount;
	private Vector3 spawnPos;
	GameObject prefab;
	

	// Use this for initialization
	void Start () {
		resourceCount =0;
		this.timeSinceRoll = 0f;
	
	}
	public void DebrisIntake (EarthDebris debris){
		resourceCount += debris.materialsMod;
		PlayerManager.control.DecInsanity(debris.sanityBoost/2);
		Destroy(debris.gameObject);
	}
			
		
	public void MatSpawner (){
		GameObject newDrop;
		while(resourceCount > 0) {	
			spawnPos = transform.position;
			newDrop = Instantiate(prefab, spawnPos, transform.rotation) as GameObject;
			resourceCount--;
		}		
	}
	private bool rollForFailure()
	{
		if (this.timeSinceRoll > this.rollTimeout)
		{
			this.timeSinceRoll = 0f;
			float roll = Random.Range(0, 1);
			if (roll < this.failProb)
			{
				return true;
			}
		}
		return false;
	}

	// Update is called once per frame
	void Update () {
		this.timeSinceRoll += Time.deltaTime;
		if (this.rollForFailure())
		{
			this.failed = true;
			Debug.Log (this.gameObject.name +" is offline");
		}
		if (this.failed) {		
			this.GetComponent<AskToFix>().GrabPlayer(this.transform.position);
		}
	
	}
}
