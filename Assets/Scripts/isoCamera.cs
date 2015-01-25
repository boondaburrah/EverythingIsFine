using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class isoCamera : MonoBehaviour
{
	public static isoCamera control;
    public GameObject target;
    public float scrollSpeed;

    private Vector3 targetPosition;
    private float timeLeft;

	void Awake() {
		if(control == null){
			control = this;
			DontDestroyOnLoad(this);
		} 
		else if (control != this) {
			Destroy (this);
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(this.gameObject == null) {return;}
	    Vector3 playerPosition = camera.WorldToViewportPoint(this.target.transform.position);
	    if (playerPosition.x < 0.3)
	    {

	        this.transform.Translate(-0.3f * Time.deltaTime * this.scrollSpeed, 0, 0);
        }
        else if (playerPosition.x > 0.7)
        {
            this.transform.Translate(0.3f * Time.deltaTime * this.scrollSpeed, 0, 0);
        }
	    if (playerPosition.y < 0.3)
	    {
	        this.transform.Translate(0, -0.3f * Time.deltaTime * this.scrollSpeed, 0);
            
        }
        else if (playerPosition.y > 0.7)
        {
            this.transform.Translate(0, 0.3f*Time.deltaTime * this.scrollSpeed, 0);
        }
        else
        {
            this.timeLeft = 0f;
        }
	}
}
