using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour 
{
	public float speed;

	// Use this for initialization
	void Start() 
	{
//		Application.targetFrameRate = 15;
//		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update() 
	{
		float position = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
		transform.position = new Vector3(Mathf.Clamp(position, -8f, 8f), -4, 0f);
	}
}
