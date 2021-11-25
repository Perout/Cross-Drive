using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SelectLocation : MonoBehaviour
{
	[SerializeField] private string _nameOfLocation;
	[SerializeField] private GameObject[] _notCurrentLocationButtons;
	[SerializeField] private Sprite _thisOne, _notThisOne;

	private void Start()
	{
		if (!PlayerPrefs.HasKey("Location"))
			PlayerPrefs.SetString("Location", "Suburb");
		if (PlayerPrefs.GetString("Location") == _nameOfLocation)
		{
			gameObject.transform.GetChild(0).transform.GetComponent<Image>().sprite = _thisOne;
		}
		else
		{
			gameObject.transform.GetChild(0).transform.GetComponent<Image>().sprite = _notThisOne;
		}
	}

	private void OnMouseUpAsButton()
	{
		PlayerPrefs.SetString("Location", _nameOfLocation);

		for (int i = 0; i < _notCurrentLocationButtons.Length; i++)
			_notCurrentLocationButtons[i].GetComponent<Image>().sprite = _notThisOne;
		gameObject.transform.GetChild(0).GetComponent<Image>().sprite = _thisOne;
	}
}
