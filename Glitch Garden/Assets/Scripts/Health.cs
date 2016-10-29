using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	
	private Stone stone;
	
	void Start() {
		stone = GetComponent<Stone>();
	}
	
	public void DealDamage(float damage) {
		health -= damage;
		
		if(stone != null) {
			stone.StoneHit();
		}
		
		if(health <= 0) {
			//Optionally trigger animation
			DestroyObject();
		}
	}
	
	public void DestroyObject() {
		Destroy(gameObject);
	}
}
