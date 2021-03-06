﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("You Win!");
			GetComponent<Renderer>().material.color = Color.red;
			Invoke("Transition", 2);
		}
	}

	private void Transition()
	{
		GetComponent<TransitionScene>().Transition();
	}
}
