using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Force : MonoBehaviour {

	private Rigidbody2D Balls;
	private float force = 1000;
	private Rotation rot;

	void Start () {
		Balls = GetComponent<Rigidbody2D> ();
		rot = GetComponent<Rotation> ();
	}
	
	// Update is called once per frame
	void Update () {
		AplicationForce ();
	}

	void AplicationForce ()
	{
		//force input space (computer)
		float x = force * Mathf.Cos (rot.zRotate * Mathf.Deg2Rad);
		float y = force * Mathf.Sin (rot.zRotate * Mathf.Deg2Rad);
		//if (Input.GetKeyUp (KeyCode.Space))
		if(rot.releaseKick == true)
		{
			Balls.AddForce (new Vector2 (x, y));
			rot.releaseKick = false;
		} 
	}
}
