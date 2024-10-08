using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextType : MonoBehaviour
{
	[SerializeField] [Tooltip("TextMeshPro Object")] 
	private TextMeshPro _script;
	[SerializeField] [Tooltip("Rect Transform Component")] 
	private RectTransform _rectTransform;
	[SerializeField] private PlayerInput _playerInput;

	[SerializeField] AudioClip[] audioClips;
    #region Keyboard Mashing
    /// <summary>
    /// Current Wingding word
    /// </summary>
    private string _currentWord = string.Empty;

	/// <summary>
	/// Current Wingding character
	/// </summary>
	private int _currentChar = 0;

	private int choicesMade;

	private Choice[] picked = new Choice[6];

	// String to contain the lorem language
    private string lorem;

    // Array to store lorem words
    private string[] words;
	#endregion
	[SerializeField] AudioSource player;
	[SerializeField] private CameraMove cam;
	[SerializeField] private posters posterchange;
	[SerializeField] printingSound printerScript;

	[SerializeField]
	private TextMeshProUGUI score;
    #region UI
	[SerializeField] 
	[Tooltip("Percent chance to prompt user for word choice after every word.")]
	[Range(0, 100)] 
	private float _promptChance;
    /// <summary>
    /// Is the user currently being prompted for a word?
    /// </summary>
    private bool _inPrompt;
	[SerializeField] NostalgiaBar bar;

	[SerializeField] private Button ButtonOne;

	[SerializeField] private Button ButtonTwo;

	[SerializeField] private AudioSource SoundButtonOne;

	[SerializeField] private AudioSource SoundButtonTwo;

	[SerializeField] private TextMeshProUGUI optionOne;

	[SerializeField] private TextMeshProUGUI optionTwo;

	private Choice[] choices;

	[SerializeField] private GameObject _canvas;

	private int[] indices = new int[] { -1, -1, -1, -1, -1, -1 };

	[SerializeField] private GameObject _namePrompt;

	[SerializeField] private TextMeshProUGUI _namePromptInputField;

	private bool justStartedNewScript = false;

	private IMDb _title;

	#endregion

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
		NameMoviePrompt();
		Meter.start = false;
		Storage.ResetChoices();
	}

	// Update is called once per frame
	void Update()
	{
		if(_script.preferredHeight > _rectTransform.rect.height)
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
		if (justStartedNewScript)
		{
			justStartedNewScript = false;
			return;
		}

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
				_script.text += ' ';
			}

			_currentWord = GetAWord();
			_currentChar = 0;
			return;
		}

		_script.text += _currentWord[_currentChar];
		_currentChar++;

		if (Random.Range(0,5) < 3)
		{
            player.PlayOneShot(audioClips[Random.Range(0, 5)]);
        }
		

	}

    #region User choice prompt
    private void PromptUserForWord()
	{
		_inPrompt = true;

		_canvas.SetActive(true);
		int rand;
		//Constantly rerolls rand until rand is a number that is not in indices
		while (indices.Contains(rand = Random.Range(0, 6)));
		Debug.Log(rand);
		indices[choicesMade] = rand;
        choices = Storage.GetOptions((Options)indices[choicesMade]);
        optionOne.text = choices[0].Title;
        optionTwo.text = choices[1].Title;
		SetButtons(true);

		
		cam.moveCamUp();
	}

	private void DeleteWords()
	{
		_script.text = _script.text.Substring(15);
	}
	public void AddChoiceOne()
	{
		picked[choicesMade] = choices[0];
		choices[0].Picked();
		choices[1].NotPicked();
		SoundButtonOne.Play();
		_script.text += $"<font=\"Roboto-Regular SDF> {choices[0].Title} </font>";
		ChoiceMade();
	}
    public void AddChoiceTwo()
    {
        picked[choicesMade] = choices[1];
        choices[1].Picked();
        choices[0].NotPicked();
        SoundButtonTwo.Play();
        _script.text += $"<font=\"Roboto-Regular SDF> {choices[1].Title} </font>";
		ChoiceMade();
    }

	private void ChoiceMade()
	{
		cam.moveCamDown();
		choicesMade++;
		_inPrompt = false;
		SetButtons(false);
		//new page of scripts
        if (choicesMade == 6)
        {
			float total = 0;
			foreach(Choice c in picked)
			{
				total += c.Nostalgia;
				Debug.Log(c.Title+": "+c.Nostalgia);
			}
			Debug.Log(total);
			bar.ChangeNostalgia(total);
			score.text = (Storage.GetApproval(picked)).ToString() + "%";
			for(int i = 0; i < picked.Length; i++)
			{
				picked[i] = null;
				indices[i] = -1;
			}
			choicesMade = 0;
			_script.text = string.Empty;
			_script.text += 
				$"<font=\"Roboto-Regular SDF><size=190%>{_title.NewTitle()}" +
				$"<size=100%></font><br><br>";
			posterchange.changePoster();
			Score.FinalScore = _title.Iteration;
			printerScript.playSound();
        }
	}

	private void SetButtons(bool onOrOff)
	{
		ButtonOne.interactable = onOrOff;
		ButtonTwo.interactable = onOrOff;
	}
    #endregion

    #region Script Name prompt
    public void NameMoviePrompt()
	{
		//Spawn Text input
		_playerInput.SwitchCurrentActionMap("UI");
		_namePrompt.SetActive(true);
	}

	public void SubmitTitle(InputAction.CallbackContext context)
	{
		if (!context.performed || _namePromptInputField.text.Length < 1)
		{
			return;
		}
		BackToGameplay(_namePromptInputField.text);
		Meter.start = true;
	}

	public void BackToGameplay(string name)
	{
		print(name);
		_namePrompt.SetActive(false);
		_playerInput.SwitchCurrentActionMap("Gameplay");
		justStartedNewScript = true;
		_title = new IMDb(name);
		_script.text += 
			$"<font=\"Roboto-Regular SDF><size=190%>{name}" +
			$"<size=100%></font><br><br>";
    }
	#endregion
}

public static class Meter
{
    public static bool start = false;
}