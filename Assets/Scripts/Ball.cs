using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	public Vector2 initialVelocity;

	bool _alive;
	Rigidbody2D _rigidBody;
	GameController _gameController;

	// Use this for initialization
	void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_gameController = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (Input.GetButtonDown("Fire1") == true && _alive == false)
		{
			_rigidBody.isKinematic = false;
			_rigidBody.AddForce(initialVelocity);

			_alive = true;
		}

		if (_alive == true && transform.position.y < -4)
		{
			_gameController.OnBallOutOfBounds();

			Destroy(gameObject);
		}
	}
}
