using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]

public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int starAmount = 500;
	
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars(int amount){
		starAmount += amount;
		UpdateDisplay();
	}
	
	public Status UseStars(int amount){
		if(starAmount >= amount){
			starAmount -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		starText.text = starAmount.ToString();
	}
}
