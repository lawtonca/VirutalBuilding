using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneThatWork: MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			SceneManager.LoadScene("BarrelRoom");
		}
	}
}