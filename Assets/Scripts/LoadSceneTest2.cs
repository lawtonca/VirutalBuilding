using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadSceneTest2 : UnityEngine.MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.B))
		{
			SceneManager.LoadScene("Scene2");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
