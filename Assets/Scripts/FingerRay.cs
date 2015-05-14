/*
Author: Trevor Richardson
FingerRay.cs
03-03-2015

	Projects a ray from the index finger that changes the color
	of the brick currently colliding with the ray and adds a 
	large, random force to the object in the direction of the ray
	if the LMB is released.
	
 */

using UnityEngine;
using System.Collections;

public class FingerRay : MonoBehaviour {

	Ray fingerRay;
	RaycastHit rayHit;
	GameObject currObject;
	GameObject lastObject;
	
	void Update() {

		// creates a ray emanating from the infex finger
		fingerRay = new Ray(transform.position, transform.up);
		// determines if the ray is hitting a brick
		if(Physics.Raycast(fingerRay, out rayHit, 65, 1<<LayerMask.NameToLayer("Bricks"))) {
			// get current object
			currObject = rayHit.transform.gameObject;
			// if a new brick is now selected, revert the color of the previous brick
			if (lastObject && currObject != lastObject)
				lastObject.renderer.material.color = Color.red;
			lastObject = rayHit.transform.gameObject;
			// set the selected brick's color to green
			currObject.renderer.material.color = Color.green;
			// add a large, random force to the selected brick when LMB is relaased
			if (Input.GetMouseButtonUp(0))
				rayHit.rigidbody.AddForce(fingerRay.direction * Random.Range(10000f, 20000f));
		}
		// revert color if nothing selected
		else if (currObject)
			currObject.renderer.material.color = Color.red;
	}
}
