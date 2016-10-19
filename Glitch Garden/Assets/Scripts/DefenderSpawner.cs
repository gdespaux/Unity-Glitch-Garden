using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	
	void Start(){
		defenderParent = GameObject.Find("Defenders");
		
		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick(Input.mousePosition);
		Vector2 roundedPos = SnapToGrid(rawPos);
		GameObject newDefender = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
		
		newDefender.transform.parent = defenderParent.transform;
	
		print (SnapToGrid (CalculateWorldPointOfMouseClick(Input.mousePosition)) );
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPosition){
		float x = Mathf.RoundToInt(rawWorldPosition.x);
		float y = Mathf.RoundToInt(rawWorldPosition.y);
		
		//prevent rounding errors outside game grid
		x = Mathf.Clamp(x, 1.0f, 9.0f);
		y = Mathf.Clamp(y, 1.0f, 5.0f);
		
		return new Vector2(x, y);
	}
	
	Vector2 CalculateWorldPointOfMouseClick(Vector3 mousePosition){
		
		float x = (float) mousePosition.x;
		float y = (float) mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(x, y, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
}
