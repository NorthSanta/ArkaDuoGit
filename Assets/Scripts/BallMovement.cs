using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	[SerializeField] private Rigidbody2D _rb;
	private bool collide;
	public float _speedX;
	public float _speedY;

	public bool _start;

    public Transform _restartPosTop;
    public Transform _restartPosBot;

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
			//_speedX = -_speedX;
			_speedY = -_speedY;				
		}
		else if (other.gameObject.CompareTag("LimitsSide"))
		{
			_speedX = -_speedX;
					
		}
        else if (other.gameObject.CompareTag("Ball"))
        {
            _speedY = -_speedY;
        }
        if (other.gameObject.CompareTag("LimitsBot"))
		{
			print("Restart");
            GameManager._padBarGoals++;
            GameManager.Instance.UpdateTexts();
            RestartPosition(0);
		}
        if (other.gameObject.CompareTag("LimitsTop"))
        {
            print("Restart");
            GameManager._touchBarGoals++;
            GameManager.Instance.UpdateTexts();
            RestartPosition(1);
        }

    }

    public void RestartPosition(int i)
    {
        switch (i)
        {
            case 0:
                transform.localPosition = _restartPosBot.localPosition;
                int rndA = Random.Range(0, 2);
                _speedX = rndA < 1 ? -100 : 100;
                _speedY = 100;

                break;
            case 1:
                transform.localPosition = _restartPosTop.localPosition;
                int rndB = Random.Range(0, 2);
                _speedX = rndB < 1 ? -100 : 100;
                _speedY = -100;
                break;
        }
    }

}
