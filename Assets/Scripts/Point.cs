/*
Author: Trevor Richardson
Point.cs
03-03-2015

	Simple script for pointing the arm with the mouse.
	
 */

using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {
	
	float mouseSensitivity = 75.0f;
	
	// points the arm in the direction the mouse is aiming
	void Update () {
		transform.LookAt(Camera.main.ScreenPointToRay(Input.mousePosition).direction * mouseSensitivity);
	}

}
