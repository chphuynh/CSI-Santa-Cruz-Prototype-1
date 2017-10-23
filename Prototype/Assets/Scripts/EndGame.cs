using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public void Exit()
	{
		Application.Quit();
	}

	public void Restart()
	{
		SceneManager.LoadScene("Room 1");
	}
}
