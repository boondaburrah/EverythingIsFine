using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


public class PowerGenerator : MonoBehaviour {
	
	public List<PowerNode> children;
    

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    

    public void cascadeFailure()
    {
        foreach (PowerNode node in children)
        {
            node.fail();
        }
    }
	
}

