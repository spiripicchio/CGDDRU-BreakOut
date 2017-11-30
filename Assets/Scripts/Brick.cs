using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour 
{
	public GameObject explosionPrefab;

	GameController _gameController;


	void Awake()
	{
		_gameController = FindObjectOfType<GameController>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		_gameController.OnBrickDestroyed();

		if (explosionPrefab != null)
		{
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}

		Destroy(gameObject);
	}
}
