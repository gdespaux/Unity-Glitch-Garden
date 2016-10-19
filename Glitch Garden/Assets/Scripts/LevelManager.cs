using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	void Start(){
		if(Application.loadedLevel == 0){ //if on Splash Screen
			Invoke("LoadMenu", 5f);
		}
	}
	
	void LoadMenu(){
		Application.LoadLevel("Start");
	}

	public void LoadLevel(string name){
		Debug.Log("Level load requested for " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitGame(){
	Debug.Log("Quit requested!");
	Application.Quit();
	}

}
