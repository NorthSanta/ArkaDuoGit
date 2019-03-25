using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			other.gameObject.GetComponent<BallMovement>()._speedY = -other.gameObject.GetComponent<BallMovement>()._speedY;
            //other.gameObject.GetComponent<BallMovement>()._speedX = -other.gameObject.GetComponent<BallMovement>()._speedX;
            
			Destroy(gameObject);
		}
	}
}
