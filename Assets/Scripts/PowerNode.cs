﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerNode : MonoBehaviour {
	public float rateIncrease;
	public int minCap;
    public bool failed;
	public PowerNode parent;
	public List<PowerNode> children;	
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fail()
    {
        this.failed = true;
    }
}
