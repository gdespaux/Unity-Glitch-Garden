using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{

	private bool isPaused = false;

	public void PauseGame ()
	{
		if (!isPaused) {
			Time.timeScale = 0;
			isPaused = true;
		} else {
			Time.timeScale = 1;
			isPaused = false;
		}
	}
}
