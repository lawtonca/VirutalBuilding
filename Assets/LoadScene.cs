using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene: MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			SceneManager.LoadScene("GuitarRoom");
		}
	}
}