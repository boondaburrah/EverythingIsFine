using UnityEngine;
using System.Collections;

public class FoodSynth : MonoBehaviour {

	public PowerGenerator parent;
	public bool hasPower;
	public bool failed;
	public float failRate;
	public float timeSinceRoll;
	public float failProb;
	public float rollTimeout;
	public float rad;
	public GameObject prefab;
	
	void Start () {
		this.timeSinceRoll = 0f;
	}

	void Update ()
	{
		this.timeSinceRoll += Time.deltaTime;
		if (this.rollForFailure())
		{
			this.failed = true;
			Debug.Log (this.gameObject.name +" is offline");
		}
		if (this.failed) {		
			this.GetComponent<AskToFix>().GrabPlayer(this.transform.position);
		}
		else{
			OfferFood();
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
	public void OfferFood (){
		Collider[] activeArea = Physics.OverlapSphere(this.transform.position, rad);
		for (int i = 0; i < activeArea.Length; i++){
			if(activeArea[i].gameObject.tag == "Player") {
				/*present food button
				  if they press yes:*/
				DropFood();
				/*else {throw lack of materials message}*/
			}
		}
	}
	public void DropFood () {
		GameObject newDrop;
		newDrop = Instantiate(prefab, this.transform.position, this.transform.rotation) as GameObject;
	}
	
	private void FixUp (){
		this.failed = false;
		this.timeSinceRoll = 0f;
		this.failProb++;
	}
}
