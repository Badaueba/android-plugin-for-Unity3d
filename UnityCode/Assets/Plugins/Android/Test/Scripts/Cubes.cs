using UnityEngine;
using System.Collections;

public class Cubes : MonoBehaviour {

	private  Transform t;
	private int speed;
	private Vector3 rotationVector;
	private Vector3 scaleVector;
	void Awake(){
		t = this.GetComponent<Transform> ();
		speed = Random.Range (10, 200);

		rotationVector =
			new Vector3 (Random.Range (1, 3), Random.Range (5, 10),Random.Range (1, 5));
		scaleVector = 
			new Vector3 (Random.Range (0.5f, 1.5f), Random.Range (0.5f, 1.5f),Random.Range (0.5f, 1.5f));
		
		t.localScale = scaleVector;
		
	}
	void Update () {
		transform.Rotate (rotationVector * Time.deltaTime * speed);
	}
}
