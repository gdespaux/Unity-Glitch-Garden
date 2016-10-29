using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	public void StoneHit () {
		anim.Play ("attacked");
	}
}
