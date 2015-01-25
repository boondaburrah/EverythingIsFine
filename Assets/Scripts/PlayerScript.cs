using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float jumpheight;
    public float rotSpeed;

	// Use this for initialization
	void Start () {
		
	
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
        // rigidbody.AddForce(movement * speed * Time.deltaTime);
        this.transform.position = this.transform.position + (movement * this.speed * Time.deltaTime);
	    if (movement.magnitude > 0.1)
	    {
	        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(movement),
	            this.rotSpeed);
	    }
	}
	
	
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PickUp"){
			other.gameObject.SetActive(false);
			
		}
	}
}
