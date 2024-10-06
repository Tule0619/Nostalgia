using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovieNamePromptScript : MonoBehaviour
{
	[SerializeField] private TMP_InputField _field;

	protected void OnEnable()
	{
		_field.Select();
	}
}

