using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;
	
	private Button[] buttonArray;
	private Text costText;

	// Use this for initialization
	void Start() {
		buttonArray = GameObject.FindObjectsOfType<Button>();

		costText = GetComponentInChildren<Text>();
		costText.text = CheckStarCost().ToString();
	}
	
	int CheckStarCost() {
		Defender thisDefender = defenderPrefab.GetComponent<Defender>();
		return thisDefender.starCost;
	}
	
	void OnMouseDown() {
		
		foreach(Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
