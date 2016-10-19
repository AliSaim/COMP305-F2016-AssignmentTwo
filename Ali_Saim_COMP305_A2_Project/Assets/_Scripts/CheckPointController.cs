using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {
	//PRIVATE INSTANCE VARIABLES
	private Transform _transform;

	//PUBLIC INSTANCE VARIABLES (FOR TESTING)
	public Transform spwanPoint;


	// Use this for initialization
	void Start () 
	{
		this._transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			this.spwanPoint.position = this._transform.position;
		}
			
	}
}
