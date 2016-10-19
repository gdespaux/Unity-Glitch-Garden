using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print(PlayerPrefsManager.GetMasterVolume());
		PlayerPrefsManager.SetMasterVolume(0.6f);
		print (PlayerPrefsManager.GetMasterVolume());
		
		print (PlayerPrefsManager.LevelUnlocked(2));
		PlayerPrefsManager.UnlockLevel(2);
		print (PlayerPrefsManager.LevelUnlocked(2));
		
		print(PlayerPrefsManager.GetDifficulty());
		PlayerPrefsManager.SetDifficulty(1);
		print (PlayerPrefsManager.GetDifficulty());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
