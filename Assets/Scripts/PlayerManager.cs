using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public float health;
	public float hunger;
	public float insanity;
	public float oxygen;
	public float timeElapsed;
	public float score;
	public float o2LossRate;
	public float digestion;
	public float hungerThreshold;
	public float hungerPangs;
	bool inSafeZone;
	bool dead;
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
	
	
	void CheckSafeZone() {
		if(SafeZoneExists()){
			inSafeZone = true;
		}
	}	
	bool SafeZoneExists() {
		return true;
	}
	// Update is called once per frame
	void Update () {
		if(dead) {return;}
		if(health == 0 || insanity == 0){
			dead = true;
			return;
		}
		CheckSafeZone();
		if(!inSafeZone){
			oxygen -= o2LossRate * Time.deltaTime;
		}
		hunger -= digestion*Time.deltaTime;
		if(hunger < hungerThreshold){
			health -= hungerPangs *Time.deltaTime;	
		}
	}
}
