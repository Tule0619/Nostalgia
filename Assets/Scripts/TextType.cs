using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextType : MonoBehaviour
{
	[SerializeField] [Tooltip("TextMeshPro Object")] 
	private TextMeshPro _textMeshPro;
	[SerializeField] [Tooltip("Rect Transform Component")] 
	private RectTransform _rectTransform;

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

	private int choicesMade;

	// String to contain the lorem language
    private string lorem;

    // Array to store lorem words
    private string[] words;

	[SerializeField] private CameraMove cam;

	/// <summary>
	/// Is the user currently being prompted for a word?
	/// </summary>
	private bool _inPrompt;

	[SerializeField] private Button ButtonOne;

	[SerializeField] private Button ButtonTwo;

	[SerializeField] private TextMeshProUGUI optionOne;

	[SerializeField] private TextMeshProUGUI optionTwo;

	private Choice[] choices;

	[SerializeField] private GameObject _canvas;

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
		if(_textMeshPro.preferredHeight > _rectTransform.rect.height)
		{
			DeleteWords();
		}

		if (_inPrompt)
		{
			cam.moveCamUp();
		} 
		else
		{
			cam.moveCamDown();
		}
	

		//new page of scripts
        if (choicesMade == 6)
        {
            _textMeshPro.text = "";
        }
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
			// Prompt user for choice
			if (Random.Range(0, 101) < _promptChance)
			{
                PromptUserForWord();
			}
			//Otherwise just go to next word.
			else
			{
				_textMeshPro.text += ' ';
			}

			_currentWord = GetAWord();
			_currentChar = 0;
			return;
		}

		_textMeshPro.text += _currentWord[_currentChar];
		_currentChar++;
	}

	private void PromptUserForWord()
	{
		_inPrompt = true;

		_canvas.SetActive(true);
        choices = Storage.GetOptions((Options)Random.Range(0, 6));
        optionOne.text = choices[0].Title;
        optionTwo.text = choices[1].Title;
		SetButtons(true);

		cam.moveCamUp();
        print("prompted");
	}

	private void DeleteWords()
	{
		_textMeshPro.text = _textMeshPro.text.Substring(15);
	}
	public void AddChoiceOne()
	{
		_textMeshPro.text += $"<font=\"Roboto-Regular SDF> {choices[0].Title} </font>";
		ChoiceMade();
	}
    public void AddChoiceTwo()
    {
		_textMeshPro.text += $"<font=\"Roboto-Regular SDF> {choices[1].Title} </font>";
		ChoiceMade();
    }

	private void ChoiceMade()
	{
		cam.moveCamDown();
		choicesMade++;
		_inPrompt = false;
		SetButtons(false);
	}

	private void SetButtons(bool onOrOff)
	{
		ButtonOne.interactable = onOrOff;
		ButtonTwo.interactable = onOrOff;
	}

	public void NameMoviePrompt()
	{
		//Spawn Text input
	}

	public void StartNewScript()
	{
		//Destroy Text input
	}
}
