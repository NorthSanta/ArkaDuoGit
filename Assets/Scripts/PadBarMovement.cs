using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadBarMovement : MonoBehaviour
{
	private Rigidbody2D _rb;
	public float _speed;
	
	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager._isReady) return;
		if (Input.GetKey(KeyCode.A))
		{
			_rb.velocity = Vector2.left * _speed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			_rb.velocity = Vector2.left * -_speed;
		}
		else
		{
			_rb.velocity = Vector2.zero;
		}
	}
}
