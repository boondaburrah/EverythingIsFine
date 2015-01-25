using UnityEngine;
using System.Collections;

public class AskToFix : MonoBehaviour {
	public static AskToFix instance;
	public float rad;
	public float sanFixCost;
	public float matFixCost;
	public bool asking;
	public bool noFix;
	public bool hasPower;
	public bool failed;
	public float failRate;
	public float timeSinceRoll;
	public float failProb;
	public float rollTimeout;
	public PowerGenerator generator;

	void Awake() {
		instance = this;
	}
	void Start () {
		asking =false;
		noFix = false;
		this.timeSinceRoll = 0f;
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
	public void FixUp (){
		this.failed = false;
		this.timeSinceRoll = 0f;
		this.failProb++;
	}
	
	public void GrabPlayer (Vector3 center){
		Collider[] activeArea = Physics.OverlapSphere(center, rad);
		for (int i = 0; i < activeArea.Length; i++){
			if(activeArea[i].gameObject.tag == "Player") {
				if(!noFix) {asking = true;}
				if(Input.GetKeyDown("return")){
					if(HasMats(activeArea[i].gameObject)){
						Debug.Log("Sending FixUP");
						FixUp ();
						this.DamageSanity(activeArea[i].gameObject);
					}
					else {asking = false; noFix = true;}
				}
			}
			else{
				noFix = false;
				asking = false;
			}
		}
	}

	private void DamageSanity (GameObject Player) {
		Player.GetComponent<PlayerManager>().DecInsanity(this.sanFixCost);
	}

	void OnGUI () {
		if(asking){
			GUI.Label (new Rect(300,300,200,100),"Press \"return\" to Fix");
		}
		else if(noFix) {
			GUI.Label (new Rect(300,300,200,100),"Oh no, I need more materials! I can't handle this!");
		}
	
	}	

	bool HasMats (GameObject Player) {
		if (Player.GetComponent<Inventory>().getCraftCount() >= this.matFixCost){
			return true;
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
			GrabPlayer(this.transform.position);
			if(this.GetComponent<PowerGenerator>() != null){
				this.GetComponent<PowerGenerator>().cascadeFailure();
			}
		}
	}
}
