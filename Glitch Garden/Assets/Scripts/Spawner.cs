using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackerPrefabArray){
			if(isTimeToSpawn(attacker)){
				Spawn (attacker);
			}
		}
	}
	
	void Spawn(GameObject attacker){
		GameObject newAttacker = Instantiate(attacker) as GameObject;
		newAttacker.transform.parent = transform;
		newAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject attacker){
		Attacker thisAttacker = attacker.GetComponent<Attacker>();
		
		float meanSpawnDelay = thisAttacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		if(Random.value < threshold){
			return true;
		} else {
			return false;
		}
	}
}
