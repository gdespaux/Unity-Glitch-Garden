using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		if(attacker){
			Health health = collider.gameObject.GetComponent<Health>();
			Debug.Log(this + " collided with " + collider + " attacker!");
			if(health){
				Debug.Log (collider + " is dealt " + damage + " damage!");
				health.DealDamage(damage);
				Destroy (gameObject);
			}
		}
	}
	
}
