using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Rigidbody2D _rigitbody;
	private Animator _animator;
	private float _move;
	private float _jump;
	private bool _isFacingRight;
	private bool _isPlayerGrounded;
	private GameObject _spawnPoint;
	private GameObject _camera;


	//PUBLIC INSTANCE VARIABLES(for TESTING)
	public float velocity = 25f;
	public float jumpForce = 100f;



	[Header("Sound Clips")]
	public AudioSource jumpSound;
	public AudioSource deadSound;


	// Use this for initialization
	void Start () 
	{
		this._initialize ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (this._isPlayerGrounded) 
		{
			//Check if input is present for movement
			this._move = Input.GetAxis ("Horizontal");
			if (this._move > 0f) 
			{
				//set the animation to run
				this._animator.SetInteger ("HeroState", 1);
				this._move = 1f;
				this._isFacingRight = true;
				this._flip ();
			} 
			else if (this._move < 0f) 
			{
				this._animator.SetInteger ("HeroState", 1);
				this._move = -1f;
				this._isFacingRight = false;
				this._flip ();
			} 
			else 
			{
				//set the animation state to idle
				this._animator.SetInteger ("HeroState", 0);
				this._move = 0f;
			}

			//check if input is present for jumping
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				this._jump = 1f;
				this.jumpSound.Play ();
			}
				
			this._rigitbody.AddForce (new Vector2 (this._move * this.velocity, this._jump * this.jumpForce), ForceMode2D.Force);

		}
		else 
		{
			this._move = 0f;
			this._jump = 0f;
		}


		this._camera.transform.position = new Vector3 (
			this._transform.position.x,
			this._transform.position.y,
			-10f);
	



		Debug.Log (this._isPlayerGrounded);
	}

	//PRIVATE METHODS
	//This method initializes variables and objects when called
	private void _initialize()
	{
		this._transform = GetComponent<Transform> ();
		this._rigitbody = GetComponent<Rigidbody2D> ();
		this._animator = GetComponent<Animator> ();
		this._camera = GameObject.FindWithTag ("MainCamera");
		this._spawnPoint = GameObject.FindWithTag ("SpawnPoint");
		this._move = 0f;
		this._isFacingRight = true;
		this._isPlayerGrounded = false;

	}

	//this methods flips the hero bitmap across the x- axis
	private void _flip()
	{
		if (this._isFacingRight) 
		{
			this._transform.localScale = new Vector2 (0.25f, 0.4f);
		} 
		else 
		{
			this._transform.localScale = new Vector2 (-0.25f, 0.4f);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("DeathPlane")) 
		{
			//move the player's position to the spawn's point position
			this._transform.position = this._spawnPoint.transform.position;
			this.deadSound.Play();
		}
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Plateform")) 
		{
			this._isPlayerGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		this._animator.SetInteger ("HeroState", 2);
		this._isPlayerGrounded = false;
	}
}
