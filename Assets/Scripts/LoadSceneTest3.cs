using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadSceneTest3 : UnityEngine.MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.C))
		{
			SceneManager.LoadScene("Scene3");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
