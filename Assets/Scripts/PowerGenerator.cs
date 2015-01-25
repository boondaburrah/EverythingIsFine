using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


public class PowerGenerator : MonoBehaviour {
	public float failRate;
	public bool failed;
	public float matFixCost;
	public float sanFixCost;
	public bool hasMats;
	public List<PowerNode> children;
    public float rollTimeout;
    public float failureProbability;

    private double timeSinceRoll;

	// Use this for initialization
	void Start ()
	{
	    this.timeSinceRoll = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.timeSinceRoll += Time.deltaTime;
	    if (this.rollForFailure())
	    {
	        this.failed = true;
            this.cascadeFailure();
			Debug.Log (this.gameObject.name +" is offline");
	    }
	}

    private bool rollForFailure()
    {
        if (this.timeSinceRoll > this.rollTimeout)
        {
            this.timeSinceRoll = 0f;
            float roll = Random.Range(0, 1);
            if (roll < this.failureProbability)
            {
                return true;
            }
        }
        return false;
    }

    private void cascadeFailure()
    {
        foreach (PowerNode node in children)
        {
            node.fail();
        }
    }
}
