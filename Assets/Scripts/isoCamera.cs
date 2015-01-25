using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class isoCamera : MonoBehaviour
{
    public GameObject target;

    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 playerPosition = camera.WorldToViewportPoint(this.target.transform.position);
	    if (playerPosition.x < 0.2)
	    {
	        this.transform.Translate(-0.2f, 0, 0);
        }
        else if (playerPosition.x > 0.8)
        {
            this.transform.Translate(0.2f, 0, 0);
        }
	    if (playerPosition.y < 0.2)
	    {
	        this.transform.Translate(0, -0.2f, 0);
            
        }
        else if (playerPosition.y > 0.8)
        {
            this.transform.Translate(0, 0.2f, 0);
        }
	}
}
