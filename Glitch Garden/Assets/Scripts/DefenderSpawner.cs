using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	void Start() { 
		defenderParent = GameObject.Find("Defenders");
		
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if(!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}
	
	int CheckStarCost(GameObject defenderPrefab) {
		Defender thisDefender = defenderPrefab.GetComponent<Defender>();
		return thisDefender.starCost;
	}
	
	void OnMouseDown() {
		int cost = CheckStarCost(Button.selectedDefender);
		
		if(starDisplay.UseStars(cost) == StarDisplay.Status.SUCCESS) {
			Vector2 rawPos = CalculateWorldPointOfMouseClick(Input.mousePosition);
			Vector2 roundedPos = SnapToGrid(rawPos);
			GameObject newDefender = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
			
			newDefender.transform.parent = defenderParent.transform;
			
			print(SnapToGrid(CalculateWorldPointOfMouseClick(Input.mousePosition)));
		} else {
			Debug.Log("Not enough stars!");
		}
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPosition) {
		float x = Mathf.RoundToInt(rawWorldPosition.x);
		float y = Mathf.RoundToInt(rawWorldPosition.y);
		
		//prevent rounding errors outside game grid
		x = Mathf.Clamp(x, 1.0f, 9.0f);
		y = Mathf.Clamp(y, 1.0f, 5.0f);
		
		return new Vector2(x, y);
	}
	
	Vector2 CalculateWorldPointOfMouseClick(Vector3 mousePosition) {
		
		float x = (float)mousePosition.x;
		float y = (float)mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(x, y, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
}
