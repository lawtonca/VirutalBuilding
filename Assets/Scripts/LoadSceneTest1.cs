using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadSceneTest1 : UnityEngine.MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
		{
			SceneManager.LoadScene("Scene1");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
