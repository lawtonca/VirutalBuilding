using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetTracking : MonoBehaviour {
	public List<Vector3> Locations = new List<Vector3>();

	float timeSinceLastRecord = 0;
	float HowOftenToUpdate = (float) .5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastRecord += Time.deltaTime;

		if (timeSinceLastRecord >= HowOftenToUpdate) {
			Vector3 loc = transform.position;
			Locations.Add (loc);	
		}
	}
}
