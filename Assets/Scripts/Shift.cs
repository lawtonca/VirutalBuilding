using UnityEngine;
using UnityEngine.SceneManagement;


public class Shift: MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.D)){
			SceneManager.LoadScene("BedRoom");
		}
	}
}