using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//Private Instance VARIABLES
	private Transform _transform;
	private Rigidbody2D _rigitbody;
	private bool _isGrounded;
	private bool _isGroundAHead;
	private bool _isPlayerDetected;


	//public Instance variables for testing
	public float speed = 5f;
	public float maxSpeed = 4f;
	public Transform sightStart;
	public Transform sightEnd;
	public Transform lineOfSight;



	// Use this for initialization
	void Start () {
		//make a reference to this object's Trannsform and RigitBody2D components
		this._transform = GetComponent<Transform> ();
		this._rigitbody = GetComponent<Rigidbody2D> ();
		this._isGrounded = false;
		this._isGroundAHead = true;
		this._isPlayerDetected = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//check if the object is grounded
		if (this._isGrounded) {
			//move the object in the direction of his local scale
			this._rigitbody.velocity = new Vector2(this._transform.localScale.x, 0) * this.speed;

			this._isGroundAHead = Physics2D.Linecast(
				sightStart.position,
				sightEnd.position,
				1 << LayerMask.NameToLayer("Solid"));



			this._isPlayerDetected = Physics2D.Linecast(
				sightStart.position,
				lineOfSight.position,
				1 << LayerMask.NameToLayer("Player"));
			


			//check is there is ground a head to walk
			if (this._isGroundAHead == false) {
				//flip the direction
				this._flip();
			}


			//check if player is detected and then increase the speed
			if (this._isPlayerDetected) {
				//increase speed to maximum of 4
				this.speed *= 2;
				if (this.speed >= maxSpeed) {
					this.speed = maxSpeed;
				}
			}

		}
	}

	//object is colliding with another one of its kind - then flip direction
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			this._flip ();
		}
	}


	//object is grounded if it stays on the plateform
	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Plateform")) {
			this._isGrounded = true;
		}
	}


	//object is not grounded if it leaves the plateform
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Plateform")) {
			this._isGrounded = false;
		}
	}


	//this methods flips the hero bitmap across the x- axis
	private void _flip()
	{
		if (this._transform.localScale.x == 1) 
		{
			this._transform.localScale = new Vector2 (-1, 1f);
		} 
		else 
		{
			this._transform.localScale = new Vector2 (1f, 1f);
		}
	}
}
