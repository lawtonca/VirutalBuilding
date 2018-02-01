using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Update () {
		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha1))
		{
			SceneManager.LoadScene("BarrelRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha2))
		{
			SceneManager.LoadScene("BedRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha3))
		{
			SceneManager.LoadScene("BenchRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha4))
		{
			SceneManager.LoadScene("BoatRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha5))
		{
			SceneManager.LoadScene("CouchRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha6))
		{
			SceneManager.LoadScene("DeskRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha7))
		{
			SceneManager.LoadScene("GuitarRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha8))
		{
			SceneManager.LoadScene("MotorcycleRoom");
		}

		else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.Alpha9))
		{
			SceneManager.LoadScene("PianoRoom");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.A))
		{
			SceneManager.LoadScene("SinkRoom");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.B))
		{
			SceneManager.LoadScene("BarrelRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.C))
		{
			SceneManager.LoadScene("BedRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.D))
		{
			SceneManager.LoadScene("BenchRoomProtractor");
		}
	
		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.E))
		{
			SceneManager.LoadScene("BoatRoomProtractor");
		}
		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.F))
		{
			SceneManager.LoadScene("CouchRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.G))
		{
			SceneManager.LoadScene("DeskRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.H))
		{
			SceneManager.LoadScene("GuitarRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.I))
		{
			SceneManager.LoadScene("MotorcycleRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.J))
		{
			SceneManager.LoadScene("PianoRoomProtractor");
		}

		if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.K))
		{
			SceneManager.LoadScene("SinkRoomProtractor");
		}

	}
	

	}
