using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Rigidbody2D _rigitbody;
	private float _move;


	//PUBLIC INSTANCE VARIABLES(for TESTING)
	public float velocity = 25f;

	public Camera camera;


	// Use this for initialization
	void Start () {
		this._initialize ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Check if input is present for movement
		this._move = Input.GetAxis("Horizontal");
		if (this._move > 0f) 
		{
			this._move = 1f;	
		} 
		else if (this._move < 0f) 
		{
			this._move = -1f;			
		} 
		else 
		{
			this._move = 0f;
		}


		this._rigitbody.AddForce (new Vector2 (this._move * velocity, 0f), ForceMode2D.Force);
		this.camera.transform.position = new Vector3 (this._transform.position.x, this._transform.position.y * 0.8f, -10f);
	
	}

	//PRIVATE METHODS
	//This method initializes variables and objects when called
	private void _initialize()
	{
		this._transform = GetComponent<Transform> ();
		this._rigitbody = GetComponent<Rigidbody2D> ();
	}
}
