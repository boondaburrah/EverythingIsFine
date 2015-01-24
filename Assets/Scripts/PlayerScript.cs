﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpheight;
	private int count;
	public string countText;

	// Use this for initialization
	void Start () {
		count = 0;
		countText = "Good Luck!";
	
	}

	void Jump () {
		rigidbody.AddForce(0, jumpheight, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float moveHoriz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");
		if(Input.GetKeyDown("space")) {
			Jump ();
		}
		Vector3 movement = new Vector3 (moveHoriz,0,moveVert);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		
	}
	void SetCountText() {
		countText = "Count: " + count.ToString();	
	}
	
	void OnGUI () {
		if(count == 6) {
			GUI.Label(new Rect(10,10,100,20), "You Won!");
		} else {
			GUI.Label(new Rect(10,10,100,20), countText);
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PickUp"){
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}
}