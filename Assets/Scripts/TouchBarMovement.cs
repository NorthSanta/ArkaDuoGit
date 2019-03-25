using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TouchBarMovement : MonoBehaviour
{

	[SerializeField] private Rigidbody2D _rb;
	public float _speed;

	private bool _firstTime;

	public GameObject _startText;

    public GameObject _padBar;
	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_firstTime = true;
	}
	
	// Update is called once per frame
	private void LateUpdate()
	{
		if(!GameManager._isReady) return;
        if (Input.GetMouseButtonUp(0) && _firstTime)
        {
            _startText.SetActive(false);
            int rndX = Random.Range(0, 2);
            transform.GetChild(0).GetComponent<BallMovement>()._speedX = rndX < 1 ? -100 : 100;
            transform.GetChild(0).GetComponent<BallMovement>()._speedY = 100;
            _padBar.transform.GetChild(0).GetComponent<BallMovement>()._speedX = rndX < 1 ? -100 : 100;
            _padBar.transform.GetChild(0).GetComponent<BallMovement>()._speedY = -100;
            _firstTime = false;
            transform.GetChild(0).SetParent(transform.parent);
            _padBar.transform.GetChild(0).SetParent(transform.parent);
        }

        if (Input.GetMouseButton(0))
		{
			if (Input.GetAxis("Mouse X") < 0)
			{
				_rb.velocity = new Vector2(Input.GetAxis("Mouse X") * _speed,0);
			}else if (Input.GetAxis("Mouse X") > 0)
			{
				_rb.velocity = new Vector2(Input.GetAxis("Mouse X") * _speed,0);
			}
			else
			{
				_rb.velocity = Vector2.zero;
			}
		}
		else
		{
			_rb.velocity = Vector2.zero;
		}
	}

}
