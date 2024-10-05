using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextType : MonoBehaviour
{
	[SerializeField] private TextMeshPro _textMeshPro;
	[SerializeField] private LoremGenerator _loremGenerator;
	private string _currentWord = string.Empty;
	private int _currentChar = 0;
	// Need to read in lorem ipsum and make player type it out when they mash the keyboard.
	public void OnType(InputAction.CallbackContext context)
	{
		if (!context.performed) return;
		if (_currentChar == _currentWord.ToString().Length)
		{
			_textMeshPro.text += ' ';
			_currentWord = _loremGenerator.GetAWord();
			_currentChar = 0;
			return;
		}

		_textMeshPro.text += _currentWord[_currentChar];
		_currentChar++;
	}

	// Start is called before the first frame update
	void Start()
	{
		_currentWord = _loremGenerator.GetAWord();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
