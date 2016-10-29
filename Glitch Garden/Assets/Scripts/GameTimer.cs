using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winText;

	// Use this for initialization
	void Start() {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		FindWinText();
		winText.SetActive(false);
	}

	void FindWinText() {
		winText = GameObject.Find("Win Text");
		if(!winText) {
			Debug.LogWarning("Please create new win text!");
		}
	}
	
	// Update is called once per frame
	void Update() {
		slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);

		if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			audioSource.Play();
			winText.SetActive(true);
			Invoke("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}
