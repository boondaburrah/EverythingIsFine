using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class isoCamera : MonoBehaviour
{
    public GameObject target;
    public float scrollSpeed;

    private Vector3 targetPosition;
    private float timeLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 playerPosition = camera.WorldToViewportPoint(this.target.transform.position);
	    if (playerPosition.x < 0.3)
	    {

	        this.transform.Translate(-0.3f * Time.deltaTime, 0, 0);
        }
        else if (playerPosition.x > 0.7)
        {
            this.transform.Translate(0.3f * Time.deltaTime, 0, 0);
        }
	    if (playerPosition.y < 0.3)
	    {
	        this.transform.Translate(0, -0.3f * Time.deltaTime, 0);
            
        }
        else if (playerPosition.y > 0.7)
        {
            this.transform.Translate(0, 0.3f*Time.deltaTime, 0);
        }
        else
        {
            this.timeLeft = 0f;
        }
	}
}
