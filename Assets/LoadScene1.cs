using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene1: MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			SceneManager.LoadScene("AT");
		}
	}
}