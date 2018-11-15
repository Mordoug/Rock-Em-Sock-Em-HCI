﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform mTarget;

    private Vector3 mCenter;
	private float mRadius = 4.0f;

	// Use this for initialization
	void Start () {
        mCenter = mTarget.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		getInput();
	}

	/* PRIVATE FUNCTIONS */
	private void getInput() {
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			if (Input.GetKey(KeyCode.RightArrow))
				Rotate(true);
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				Rotate(false);
			}
		}
		else {	// SETUP FOR MOBILE CONTROLS

		}
	}
	private Vector2 PointOnCircle(float angle) {
		float x = (mRadius * Mathf.Cos(angle * Mathf.PI / 180.0f) + mCenter.x);
		float y = (mRadius * Mathf.Cos(angle * Mathf.PI / 180.0f) + mCenter.y);

		return new Vector2(x, y);
	}

	// True for right, False for left
	private void Rotate(bool direction) {
		if (direction)
			transform.RotateAround(mCenter, new Vector3(0, 0.5f, 0), 180 * Time.deltaTime);
		else
			transform.RotateAround(mCenter, -new Vector3(0, 0.5f, 0), 180 * Time.deltaTime);
	}
}
