using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadScene : MonoBehaviour {
	public Dictionary<KeyCode, string> SceneLoads = new Dictionary<KeyCode, string>();
	public Dictionary<string, bool> SceneToMakeFile = new Dictionary<string, bool>();
	HeadSetTracking headSetTracker;
	private void Start()
	{
		//For now on we add new scene transitions this way. makes the code cleaner and easier to read
		SceneLoads.Add(KeyCode.Alpha1, "BarrelRoom");
		SceneLoads.Add(KeyCode.Alpha2, "BedRoom");
		SceneLoads.Add(KeyCode.Alpha3, "BenchRoom");
		SceneLoads.Add(KeyCode.Alpha4, "BoatRoom");
		SceneLoads.Add(KeyCode.Alpha5, "CouchRoom");
		SceneLoads.Add(KeyCode.Alpha6, "DeskRoom");
		SceneLoads.Add(KeyCode.Alpha7, "GuitarRoom");
		SceneLoads.Add(KeyCode.Alpha8, "MotorcycleRoom");
		SceneLoads.Add(KeyCode.Alpha9, "PianoRoom");
		SceneLoads.Add(KeyCode.A, "SinkRoom");
		SceneLoads.Add(KeyCode.B, "BarrelRoomProtractor");
		SceneLoads.Add(KeyCode.C, "BedRoomProtractor");
		SceneLoads.Add(KeyCode.D, "BenchRoomProtractor");
		SceneLoads.Add(KeyCode.E, "BoatRoomProtractor");
		SceneLoads.Add(KeyCode.F, "CouchRoomProtractor");
		SceneLoads.Add(KeyCode.G, "DeskRoomProtractor");
		SceneLoads.Add(KeyCode.H, "GuitarRoomProtractor");
		SceneLoads.Add(KeyCode.I, "MotorcycleRoomProtractor");
		SceneLoads.Add(KeyCode.J, "PianoRoomProtractor");
		SceneLoads.Add(KeyCode.K, "SinkRoomProtractor");
		SceneLoads.Add(KeyCode.M, "finalSceneBuilding02October2017minimap");
		SceneLoads.Add(KeyCode.X, "grayScene");
		SceneLoads.Add(KeyCode.N, "finalSceneBuilding02October2017Nominimap");

		//change false to true for all scenes that should print to the file
		SceneToMakeFile.Add("BarrelRoom", true);
		SceneToMakeFile.Add("BedRoom", true);
		SceneToMakeFile.Add("BenchRoom", true);
		SceneToMakeFile.Add("BoatRoom", true);
		SceneToMakeFile.Add("CouchRoom", true);
		SceneToMakeFile.Add("DeskRoom", true);
		SceneToMakeFile.Add("GuitarRoom", true);
		SceneToMakeFile.Add("MotorcycleRoom", true);
		SceneToMakeFile.Add("PianoRoom", true);
		SceneToMakeFile.Add("SinkRoom", true);
		SceneToMakeFile.Add("BarrelRoomProtractor", false);
		SceneToMakeFile.Add("BedRoomProtractor", false);
		SceneToMakeFile.Add("BenchRoomProtractor", false);
		SceneToMakeFile.Add("BoatRoomProtractor", false);
		SceneToMakeFile.Add("CouchRoomProtractor", false);
		SceneToMakeFile.Add("DeskRoomProtractor", false);
		SceneToMakeFile.Add("GuitarRoomProtractor", false);
		SceneToMakeFile.Add("MotorcycleRoomProtractor", false);
		SceneToMakeFile.Add("PianoRoomProtractor", false);
		SceneToMakeFile.Add("SinkRoomProtractor", false);
		SceneToMakeFile.Add("finalSceneBuilding02October2017minimap", true);
		SceneToMakeFile.Add("grayScene", false);
		SceneToMakeFile.Add("finalSceneBuilding02October2017Nominimap", true);

	}
	// Use this for initialization
	void Update () {
		//if we haven't found a reference to the HeadSetTracker code lets try to find one
		if(headSetTracker == null)
		{
			//before acces the array at index 0 we should make sure theres an object in the list
			if(FindObjectsOfType<HeadSetTracking>().Length > 0)
			{
				headSetTracker = (HeadSetTracking)FindObjectsOfType<HeadSetTracking>()[0];
			}

		}

		string SceneName = "";
		//get all keys in the dictionary, we need to look at each keycode and see if its pressed
		List<KeyCode> keys = new List<KeyCode>(SceneLoads.Keys);

		//look at each key code and see if its pressed
		foreach (KeyCode key in keys)
		{
			//test if the key is pressed
			if(Input.GetKeyDown(key))
			{
				//Test if the dicionary has this key, should since we are only looking at the keys from the dictionary
				//collect the value from this key
				if (SceneLoads.TryGetValue(key, out SceneName))
				{
					Scene currentScene = SceneManager.GetActiveScene();
					bool shouldPrint = false;
					if (SceneToMakeFile.TryGetValue(currentScene.name, out shouldPrint))
					{
						//if we have reference to a HeadSetTracker we should write to the file
						if (shouldPrint && headSetTracker != null)
						{
							headSetTracker.writeToFile(headSetTracker.GenerateFileName("Results") + "-" + currentScene.name + ".csv");
						}
					}
					//change scene
					SceneManager.LoadScene(SceneName);

					//most likely not needed but it will keep us from loading more than one level because of 'fat fingering it'
					break;
				}
			}
		}

		#region Old
		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha1))
		//{
		//	SceneManager.LoadScene("BarrelRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha2))
		//{
		//	SceneManager.LoadScene("BedRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha3))
		//{
		//	SceneManager.LoadScene("BenchRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha4))
		//{
		//	SceneManager.LoadScene("BoatRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha5))
		//{
		//	SceneManager.LoadScene("CouchRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha6))
		//{
		//	SceneManager.LoadScene("DeskRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha7))
		//{
		//	SceneManager.LoadScene("GuitarRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha8))
		//{
		//	SceneManager.LoadScene("MotorcycleRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha9))
		//{
		//	SceneManager.LoadScene("PianoRoom");
		//}

		//else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
		//{
		//	SceneManager.LoadScene("SinkRoom");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.B))
		//{
		//	SceneManager.LoadScene("BarrelRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.C))
		//{
		//	SceneManager.LoadScene("BedRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
		//{
		//	SceneManager.LoadScene("BenchRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.E))
		//{
		//	SceneManager.LoadScene("BoatRoomProtractor");
		//}
		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.F))
		//{
		//	SceneManager.LoadScene("CouchRoomProtractor");
		//}
		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.G))
		//{
		//	SceneManager.LoadScene("DeskRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.H))
		//{
		//	SceneManager.LoadScene("GuitarRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.I))
		//{
		//	SceneManager.LoadScene("MotorcycleRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.J))
		//{
		//	SceneManager.LoadScene("PianoRoomProtractor");
		//}

		//if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.K))
		//{
		//	SceneManager.LoadScene("SinkRoomProtractor");
		//}
		#endregion
	}


}