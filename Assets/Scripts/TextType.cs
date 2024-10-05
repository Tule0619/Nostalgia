using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextType : MonoBehaviour
{
	[SerializeField] [Tooltip("TextMeshPro Object")] private TextMeshPro _textMeshPro;

	/// <summary>
	/// Current Wingding word
	/// </summary>
	private string _currentWord = string.Empty;

	/// <summary>
	/// Current Wingding character
	/// </summary>
	private int _currentChar = 0;

	[SerializeField] 
	[Tooltip("Percent chance to prompt user for word choice after every word.")]
	[Range(0, 100)] 
	
	private float _promptChance;

	// String to contain the lorem language
    private string lorem;

    // Array to store lorem words
    private string[] words;

	/// <summary>
	/// Is the user currently being prompted for a word?
	/// </summary>
	private bool _inPrompt;

    void Awake()
    {
        // Set up lorem and split
        lorem = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Et error, ullam illo expedita sapiente totam repellat, temporibus corrupti ipsa dolorem esse, nostrum dolorum quisquam iure? Iusto maxime, " +
             "iste laborum amet ipsa quod nisi ducimus incidunt dolor porro velit modi praesentium quisquam, in eius dicta ipsam aut officia dolore facere placeat repellendus? Voluptatum ipsum omnis quos sed, excepturi ad eaque assumenda. " +
             "Illo, ipsum! Voluptate quidem numquam blanditiis repellat fuga quia provident distinctio, vel fugiat culpa voluptatibus quod dolore, " +
             "tenetur totam similique eligendi in? Eum nobis officia tenetur in quas deleniti inventore obcaecati cum quidem possimus. Rerum tempora quas at neque eveniet.";
        words = lorem.Split(' ');
    }

	// Start is called before the first frame update
	void Start()
	{
		_currentWord = GetAWord();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

    /// <summary>
    /// Return a random lorem word
    /// </summary>
    /// <returns></returns>
    private string GetAWord()
    {
		return words[Random.Range(0, words.Length)];
    }

	/// <summary>
	/// Start typing out wingdings on typing.
	/// </summary>
	/// <param name="context">Input action context.</param>
	public void OnType(InputAction.CallbackContext context)
	{
		if (!context.performed || _inPrompt) return;

		// Create end of a lorem ipsum word, change to next lorem ipsum word
		if (_currentChar == _currentWord.ToString().Length)
		{
			_textMeshPro.text += ' ';
			_currentWord = GetAWord();
			_currentChar = 0;

			// Prompt user for choice
			if (Random.Range(0, 101) < _promptChance)
			{
				PromptUserForWord();
				return;
			}

			return;
		}

		_textMeshPro.text += _currentWord[_currentChar];
		_currentChar++;
	}

	private void PromptUserForWord()
	{
		_inPrompt = true;
		print("prompted");
	}
}
