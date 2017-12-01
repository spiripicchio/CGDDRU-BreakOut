using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public GameObject brickPrefab;
	public int columns;
	public int rows;
	public float horizontalGap;
	public float verticalGap;
	public GameObject gameOverText;
	public GameObject winText;
	public GameObject ball;

	float _startPositionX = -7;
	float _startPositionY = 3;
	float _numberOfBricks;

	// Use this for initialization
	void Awake() 
	{
		_numberOfBricks = columns * rows;

		for (int i = 0; i < rows; ++i)
		{
			for (int j = 0; j < columns; ++j)
			{
				GameObject brick = (GameObject)Instantiate(brickPrefab);
				brick.transform.position = new Vector3(_startPositionX + j * horizontalGap, _startPositionY - i * verticalGap);
			}
		}
	}

	public void OnBrickDestroyed()
	{
		_numberOfBricks--;
		if (_numberOfBricks == 0)
		{
			StartCoroutine(WinSequence());
		}
	}

	public void OnBallOutOfBounds()
	{
		StartCoroutine(DeadSequence());
	}

	IEnumerator DeadSequence()
	{
		gameOverText.SetActive(true);

		yield return new WaitForSeconds(5);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	IEnumerator WinSequence()
	{
		Destroy(ball);

		for (int i = 0; i < 5; ++i)
		{
			winText.SetActive(true);

			yield return new WaitForSeconds(1);	

			winText.SetActive(false);

			yield return new WaitForSeconds(0.5f);
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// Update is called once per frame
	void Update() 
	{
		
	}
}
