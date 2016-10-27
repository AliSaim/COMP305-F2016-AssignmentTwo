using UnityEngine;
using System.Collections;

//reference to the UI namespcae
using UnityEngine.UI;

//Reference to manage my scenes

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	//PRIVATE INSTANCE VARIABKES +++++++++++++++++++
	private int _livesValue;
	private int _scoreValue;

	[Header("UI Objects")]
	public Text LivesLabel;
	public Text ScoreLabel;


	//PPUBLIC PROPERTIES +++++++++++++++++++++++++++
	public int LivesValue
	{
		get
		{
			return this._livesValue;
		}
		set
		{
			this._livesValue = value;

			if (this._livesValue <= 0) 
			{
				SceneManager.LoadScene ("GameOver");
				//this.LivesLabel.text = "Lives: " + this._livesValue;
			} 
			else 
			{
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}

	public int ScoreValue
	{
		get
		{
			return this._scoreValue;
		}
		set
		{
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}


	// Use this for initialization
	void Start () {
		this.LivesValue = 5;
		this.ScoreValue = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
