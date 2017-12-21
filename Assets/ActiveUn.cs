using UnityEngine;
using System.Collections;

public class ActiveUn : MonoBehaviour {

	public GameObject Cube;


	void Start()
	{
		
	}

	void Update () {

		if (Input.GetKey(KeyCode.Space))
		{
			Cube.SetActive(false);

				
		}else
			
		{

	      Cube.SetActive(true);


    }
}

}
			 