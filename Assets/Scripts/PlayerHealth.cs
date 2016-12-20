using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;



	public bool isDead;


	// Use this for initialization
	void Start () {

		currentHealth = startingHealth;
	
	}
	
	// Update is called once per frame
	public void TakeDamage (int amount) {

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {

			Death ();
		}
	
	}

	void Death(){


		isDead = true;

		Destroy (gameObject);




	}
}
