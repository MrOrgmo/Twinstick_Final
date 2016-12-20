using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {


	Transform target;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	public float speed;

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player").transform;

		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update () {

		if (playerHealth.isDead == false) {

			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}


	}
}
