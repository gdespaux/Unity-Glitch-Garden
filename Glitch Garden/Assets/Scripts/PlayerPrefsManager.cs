using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	// level_unlocked_1, _2, _3

	public static void SetMasterVolume(float volume){
		if(volume > 0f && volume < 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else{
			Debug.LogError("Volume Out Of Range!");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel(int level){
		if(level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //Use 1 for true, in place of proper bool 
		}else{
			Debug.LogError ("Trying to unlock level " + level);
		}
	}
	
	public static bool LevelUnlocked(int level){
		if(level > Application.levelCount - 1){
			Debug.LogError("Requested level " + level + " doesn't exist!");
			return false;
		} else if(PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1){
			return true;
		}
		
		return false;
	}
	
	public static void SetDifficulty(int difficulty){
		if(difficulty <= 3 && difficulty >= 1){
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty level out of range! Requested " + difficulty);
		}
	}
	
	public static int GetDifficulty(){
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}
	
}
