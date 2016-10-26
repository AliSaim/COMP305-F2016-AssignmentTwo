using UnityEngine;
using System.Collections;

public class MillController : MonoBehaviour {

	private int _milleSpeed = 1;

	//Private Instance VARIABLES
	private Transform _transform;

	// Use this for initialization
	void Start () {
		this._transform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//roate the mill on its' z scale by 1 every frame
		this._transform.Rotate (0, 0, _milleSpeed);

	}
}
