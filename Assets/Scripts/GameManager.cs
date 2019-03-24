using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance;
	[SerializeField] private GameObject _block;
	[SerializeField] private Transform _blockParent;

	public static bool _isReady;
	
	// Use this for initialization
	void Start ()
	{
		Init();
	}

	public void Init()
	{
		StartCoroutine(FillBlocks());
	}


	IEnumerator FillBlocks()
	{
		_isReady = false;
		float posX = -117.3334f;
		float posY = 40;
		for (int i = 0; i < 17; i++)
		{
			for (int j = 0; j < 12; j++)
			{
				if (Random.Range(0, 101) > 10)
				{
					GameObject miniBlock = Instantiate(_block,_blockParent);
					miniBlock.transform.localPosition = new Vector3(posX,posY);
					miniBlock.GetComponent<Image>().color = Random.ColorHSV();
				}
				
				posX += 21.3333333f;
				yield return new WaitForSeconds(0.01f);
			}

			posY -= 5;
			posX = -117.3334f;
		}

		_isReady = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
