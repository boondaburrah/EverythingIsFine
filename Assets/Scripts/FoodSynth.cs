using UnityEngine;
using System.Collections;

public class FoodSynth : MonoBehaviour {

	
	public float rad;
	public float foodVal;
	
	void Start () {
	}

	void Update ()
	{	
	}	
	
	void OnGUI(){
		Collider[] activeArea = Physics.OverlapSphere(this.transform.position, rad);
		for (int i = 0; i < activeArea.Length; i++){
			if(activeArea[i].gameObject.tag == "Player") {
				GUI.Label(new Rect(300, 300, 200, 100), "Press \"return\" to eat");
				if(Input.GetKeyDown("return")){
					DropFood(activeArea[i].gameObject);
					Debug.Log("dropping food");
				}
			}
		}
	}
	public void DropFood (GameObject player) {
		player.GetComponent<PlayerManager>().FillHunger(foodVal);	
		Debug.Log("fillhunger called");
	}
	

}
