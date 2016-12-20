using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{
	public float MaxSpeed = 5f;
	private Transform MyTransform = null;
	private Vector3 MoveDir;
	private float LookDir;

	public float xmin;
	public float xmax;
	public float zmin;
	public float zmax;

	public GameObject[] weapons;
	private int weapon;

	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;
	private float nextFire;
	public Material mat;
	public Material[] materials;
	private PlayerHealth health;

	// Use this for initialization
	void Start () 
	{
		MyTransform = GetComponent<Transform> ();
		shot = weapons [0];

		mat = gameObject.GetComponent<Renderer> ().material;

		health = GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (health.isDead == false) {


			shot = weapons [weapon];

			float x = CrossPlatformInputManager.GetAxis ("Horizontal");
			float z = CrossPlatformInputManager.GetAxis ("Vertical");

			MoveDir = new Vector3 (x, 0, z);

			MyTransform.position = new Vector3 (
			Mathf.Clamp (MyTransform.position.x, xmin, xmax),
			-6.0f,
			Mathf.Clamp (MyTransform.position.z, zmin, zmax));

			MyTransform.position += MoveDir * MaxSpeed * Time.deltaTime;

			float shootx = CrossPlatformInputManager.GetAxis ("HorizontalShoot");
			float shootz = CrossPlatformInputManager.GetAxis ("VerticalShoot");

			if (shootx == 0 & shootz == 0) {
				LookDir = 0;
			} else {
				LookDir = Mathf.Atan2 (shootx, shootz) * Mathf.Rad2Deg;

				if (Time.time > nextFire) {
					nextFire = Time.time + fireRate;
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}

			}
			MyTransform.rotation = Quaternion.Euler (new Vector3 (0, LookDir, 0));
		}
	}

	public void ChangeWeapon (){

		if(health.currentHealth <= 0)
			return;

		if (weapon == 3)
			weapon = 0;
		else
			weapon ++;

		mat = materials [weapon];
		gameObject.renderer.material = materials [weapon];

	}
}
