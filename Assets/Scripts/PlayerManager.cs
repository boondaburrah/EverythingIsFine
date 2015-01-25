using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public static PlayerManager control;
	public float health;
	public float hunger;
	public float insanity;
	public float oxygen;
	public float timeElapsed;
	private float startTime;
	public float score;
	public float o2LossRate;
	public float apoxia;
	public float digestion;
	public float hungerThreshold;
	public float hungerPangs;
	public bool inSafeZone;
	
	bool dead;

	void PrintUpdate () {
		Debug.Log("Health is: " + health.ToString());
		Debug.Log("Hunger is: " + hunger.ToString());
		Debug.Log("Insanity is: " + insanity.ToString());
		Debug.Log("Oxygen is: " + oxygen.ToString());
		Debug.Log("Health is: " + health.ToString());
		if(inSafeZone) {Debug.Log ("In Safe Zone");}
		else {Debug.Log ("Not Safe");}
	}

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad(this);
			control = this;
		}
		else if (control != this) {
			Destroy (gameObject);
		}
		timeElapsed = 0;
		startTime = Time.time;
	}
		
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);	
		dead = false;
		inSafeZone = false;
	}

	public void Damage (float val) {
		health -= val;
	}
	public void Heal (float val) {
		health += val;
	}
	public void DecInsanity (float val) {
		insanity -= val;
	}
	public void IncInsanity (float val) {
		insanity += val;
	}	


		
	// Update is called once per frame
	void Update () {
		if(dead) {return;}
		if(health <= 0 || insanity <= 0){
			dead = true;
			return;
		}
		timeElapsed = Time.time - startTime;
		if(!inSafeZone && oxygen > 0){
			oxygen -= o2LossRate * Time.deltaTime;
		}
		if(oxygen <= 0) {
			health -= apoxia * Time.deltaTime;
		}
		if(hunger >0) {hunger -= digestion*Time.deltaTime;}
		if(hunger < hungerThreshold){
			health -= hungerPangs *Time.deltaTime;	
		}
		//PrintUpdate(); //debug
	}
}
