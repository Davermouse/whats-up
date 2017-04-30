using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatModelRotate : MonoBehaviour {
	long rotationStart;

	// Use this for initialization
	void Start () {
		var rand = new System.Random ();
		rotationStart = rand.Next (360);
	}
	
	// Update is called once per frame
	void Update () {
		float ticks = (DateTime.Now.Ticks / 1000000) % 360;
			
		this.transform.rotation = 
			Quaternion.Euler(
				new Vector3(
					rotationStart + Time.deltaTime, 
					rotationStart + Time.deltaTime + 150, 
					rotationStart + Time.deltaTime + 200));
	}
}
