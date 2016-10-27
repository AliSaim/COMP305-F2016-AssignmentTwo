/* Student First Name: Ali
 * Student Last Name: Saim
 * Student Number: 300759480
 * Course: COMP305 - Fall 2016
 * Prof: Tom Tsiliopoulos
 * Last Modified by: Ali Saim
 * Date Last Modified: Oct 26th 2016
 * Programe Description: This is one of the script file that is use to make the second assignemnt for comp 305
 */
using UnityEngine;
using System.Collections;

public class PlateFormControllerVertical : MonoBehaviour {
	
	//PRIVATE INSTANCE VARIABLES +++++++++++++++++++
	private float _speed;
	private Transform _transform;
	private bool _movingUp;


	//PUBLIC INSTANCE VARIABLES(For Testing) +++++++++++++++++++
	public float maxHeight;
	public float minHeight;

	//PUBLIC PROPERTIES
	public float Speed {
		get
		{
			return this._speed;
		}
		set
		{
			this._speed = value;
		}
	}

	public float MaxHeight {
		get
		{
			return this.maxHeight;
		}
		set
		{
			this.maxHeight = value;
		}
	}

	public float MinHeight {
		get
		{
			return this.minHeight;
		}
		set
		{
			this.minHeight = value;
		}
	}
		

	// Use this for initialization
	void Start () {
		this._speed = 0.05f;
		//this._maxHeight = 14f;
		//this._minHeight = 0f;
		this._movingUp = true;
		this._transform = this.GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		this._move ();
		this._checkBounds ();
	}


	//This method moves the game object down the screen by _speed px every frame
	private void _move()
	{
		if (_movingUp) 
		{
			Vector2 newPosition = this._transform.position;
			newPosition.y += this._speed;
			this._transform.position = newPosition;
		}

		if (_movingUp == false) 
		{
			Vector2 newPos = this._transform.position;
			newPos.y -= this._speed;
			this._transform.position = newPos;
		}
	}


	//This method checks to see if the game object meets the top border of the screen
	private void _checkBounds()
	{
		if (this._transform.position.y >= maxHeight) 
		{
			this._movingUp = false;
		}

		if (this._transform.position.y <= minHeight ) 
		{
			this._movingUp = true;
		}
	}
}
