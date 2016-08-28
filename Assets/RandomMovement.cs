using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomMovement : MonoBehaviour {
	public float speed = 3f;
	private float diffculty = 0;
	private float randomFloat;
	private Vector3 fwd;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		InvokeRepeating("IncreaseDifficulty", 3f, 3f);
	}

	void IncreaseDifficulty() {
		if (speed < 12f) {
			speed += (1f * diffculty);
			diffculty++;
			print (speed);
		}


	}
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (new Vector3 (0, 0, 2) * speed * Time.deltaTime);
		randomFloat = Random.Range (0, 360);
		fwd = transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (transform.position, fwd * 3, Color.red);

		if (Physics.Raycast(transform.position,fwd, out hit, 3f)) {
			if (hit.collider.tag == "Wall") {
				transform.Rotate (0, randomFloat, 0);
			} 
			if (hit.collider.tag == "Player") {
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene (scene.name);
			}
		}

	}
}
