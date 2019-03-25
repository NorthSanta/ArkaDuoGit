using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	[SerializeField] private GameObject _block;
	[SerializeField] private Transform _blockParent;

    public static int _touchBarGoals;
    public static int _padBarGoals;

	public static bool _isReady;

    public Text _topText;
    public Text _bottomText;

    public Text _topWinText;
    public Text _bottomWinText;

    public GameObject[] _balls;

    public GameObject _restartText;
    // Use this for initialization
    void Start ()
	{
		Init();
	}

	public void Init()
	{
        Instance = this;   
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
        //UpdateTexts();

        CheckFinalGame();
	}

    public void UpdateTexts()
    {
        _bottomText.text = _touchBarGoals.ToString();
        _topText.text = _padBarGoals.ToString();
    }

    public void CheckFinalGame()
    {
        if (!_isReady) return;
        if (_blockParent.childCount == 0)
        {
            if(_padBarGoals > _touchBarGoals)
            {
                _topWinText.text = "";
                _bottomWinText.text = "LOOSER LOOSER ARKANOID HOOSER!!!";
            }
            else if (_padBarGoals < _touchBarGoals)
            {
                _topWinText.text = "LOOSER LOOSER ARKANOID HOOSER!!!";
                _bottomWinText.text = "WINNER WINNER PONG DINNER!!!";
            }
            else
            {
                _topWinText.text = "TIE TIE !!!";
                _bottomWinText.text = "TIE!!!";
            }

            _balls[0].SetActive(false);
            _balls[1].SetActive(false);

            _restartText.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
