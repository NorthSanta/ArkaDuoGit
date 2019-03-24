using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	[SerializeField] private Rigidbody2D _rb;
	private bool collide;
	public float _speedX;
	public float _speedY;

	public bool _start;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_start = false;
	}

	private void Update()
	{
		_rb.velocity = new Vector2(1 * _speedX,1*_speedY);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.CompareTag("Bar"))
		{
			_speedX = -_speedX;
			_speedY = -_speedY;				
		}
		else if (other.gameObject.CompareTag("LimitsSide"))
		{
			_speedX = -_speedX;
					
		}
		if (other.gameObject.CompareTag("LimitsTopBot"))
		{
			print("Restart");				
		}
			
	}


}
