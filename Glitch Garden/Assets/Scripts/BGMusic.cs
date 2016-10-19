using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {
	
	public AudioClip splashSound;
	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake() {
		DontDestroyOnLoad(gameObject);
		
		Invoke("PlaySplashSound", 0.5f);
		
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if(thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	void PlaySplashSound(){
		AudioSource.PlayClipAtPoint(splashSound, transform.position, 0.25f);
	}
	
	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
}
