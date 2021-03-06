﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
	public float Range = 2;
	public float Speed = 3;
	public float LeftFacingY = 180;
	public float RightFacingY = 0;

	private float _leftRange;
	private float _rightRange;

	private bool _facingRight;
	private float _target;

	// Use this for initialization
	void Start ()
	{
		_rightRange = transform.position.x + Range / 2;
		_leftRange = transform.position.x - Range / 2;
		_target = _leftRange;
		_facingRight = false;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, LeftFacingY, transform.eulerAngles.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_facingRight)
		{
			if (_target < transform.position.x)
			{
				_target = _leftRange;
				_facingRight = false;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, LeftFacingY, transform.eulerAngles.z);
			}
			else
			{
				transform.Translate(Speed * Time.deltaTime, 0, 0);
			}
		}
		else
		{
			if (transform.position.x < _target)
			{
				_target = _rightRange;
				_facingRight = true;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, RightFacingY, transform.eulerAngles.z);
			}
			else
			{
				transform.Translate(Speed * Time.deltaTime, 0, 0);
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<HousePlayer>().Restart();
		}
	}
}
