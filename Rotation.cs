using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Rotation : MonoBehaviour {

	//Position arrow
	[SerializeField]private Transform posStart;

	//Arrows
	[SerializeField]private Image arrowImage;

	//Angle
	public float zRotate;

	//Release Rotation
	public bool releaseRot = false;

	//Release Kick
	public bool releaseKick = false;

	// Use this for initialization
	void Start () {
		PositionArrows ();
		PositionBalls ();
	}
	
	// Update is called once per frame
	void Update () {
		RotationArrows ();
		inputRotation ();
		LimitRotate ();
	}
	void PositionArrows(){
		arrowImage.rectTransform.position = posStart.position;
	}

	void PositionBalls(){
		this.gameObject.transform.position = posStart.position;
	}

	void RotationArrows(){
		arrowImage.rectTransform.eulerAngles = new Vector3 (0, 0, zRotate );
	}
		
	void inputRotation(){
		//input Arrows move
		/*if (Input.GetKey (KeyCode.UpArrow)) {
			zRotate += 2.5f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			zRotate -= 2.5f;
		}*/

		//input control mobile
		if(releaseRot == true){
			float moveX = Input.GetAxis ("Mouse X");
			float moveY = Input.GetAxis ("Mouse Y");

			if(zRotate < 90)
			{
				if (moveY > 0) {
					zRotate += 2.5f;
				}
			}

			if(zRotate > 0)
			{
				if (moveY < 0) {
					zRotate -= 2.5f;
				}
			}
		}
	}

	void LimitRotate()
	{
		if(zRotate >= 90)
		{
			zRotate = 90;
		}

		if(zRotate <= 0)
		{
			zRotate = 0;
		}
	}
	void OnMouseDown()
	{
		releaseRot = true;
	}

	void OnMouseUP()
	{
		releaseRot = false;
		releaseKick = true;
	}
}
