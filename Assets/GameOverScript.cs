using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _finalScoreDisplay;
	// Start is called before the first frame update
	private void Start()
	{
		_finalScoreDisplay.text = "SCORE: " + Score.FinalScore.ToString();
	}
}
