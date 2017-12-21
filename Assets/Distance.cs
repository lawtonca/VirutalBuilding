using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {

	public GameObject Player;
	public GameObject Sphere;
	public GameObject Cube;

	public float Distance_;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Distance_ = Vector3.Distance(Player.transform.position,Sphere.transform.position);
		if(Distance_ < 3)
		{
	Debug.Log("dist");
	}
}
		}
