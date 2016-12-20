using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	
	public int startingHealth = 100;
	public int currentHealth;
	public GameObject explosion;
	public int fireDmg;
	public int airDmg;
	public int waterDmg;
	public int earthDmg;

	private int amount;
	private ShotController shot;
	private PlayerHealth player;


	bool isDead;
	
	
	// Use this for initialization
	void Start () {
		
		currentHealth = startingHealth;

		currentHealth = startingHealth;
		
	}


	void OnTriggerEnter (Collider other) {

		if (isDead)
			return;

		if (other.tag == "Player") {

			player = other.GetComponent<PlayerHealth>();

			player.TakeDamage(30);

			Death ();


		} else if (other.tag == "Bullet") {

			Debug.Log ("Ouch");

			shot = other.GetComponent<ShotController>();

			Debug.Log (shot.Element());

			if (shot.Element() == "Fire")
				amount = fireDmg;
			if(shot.Element() == "Water")
				amount = waterDmg;
			if(shot.Element() == "Air")
				amount = airDmg;
			if(shot.Element() == "Earth")
				amount = earthDmg;

			currentHealth -= amount;

			Destroy(other.gameObject);

		}



			

		
		if (currentHealth <= 0 && !isDead) {
			
			Death ();
		}
		
	}
	
	void Death(){
		
		
		isDead = true;

		Instantiate(explosion, transform.position, transform.rotation);

		ScoreManager.score += 1;
		EndScore.score += 1;


		Destroy (gameObject);

		
		
		
	}
}