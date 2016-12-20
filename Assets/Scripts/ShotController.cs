using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {
	
	public float speed;
	public string type;

	private Transform ShotTransform;
	
	
	// Use this for initialization
	void Start () {
		
		ShotTransform = GetComponent<Transform> ();
	}
	
	void Update(){
		
		ShotTransform.position +=  ShotTransform.forward * speed * Time.deltaTime;
	}

	public string Element(){

		return type;

	}

	
}