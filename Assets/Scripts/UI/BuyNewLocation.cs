
using UnityEngine.UI;
using UnityEngine;

public class BuyNewLocation : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private string _nameOfLocation;
    [SerializeField] private AudioSource _soundObj;
    [SerializeField] private AudioClip _success, _fail;
    [SerializeField] private GameObject _checkedButton;
	[SerializeField] private Sprite _unchekedButton, _checkedButtonSprite;
	[SerializeField] private GameObject[] _notCurrentLocationButtons;
	[SerializeField] private GameObject[] _buttonsToDisable;
	[SerializeField] private Text _coins;

	
	private void Awake()
	{
		if (PlayerPrefs.GetString(_nameOfLocation) == "Open")
		{
			for (int i = 0; i < _buttonsToDisable.Length; i++)
				_buttonsToDisable[i].SetActive(false);
			_checkedButton.SetActive(true);
		}

	}

	private void OnMouseUpAsButton()
	{
		if (PlayerPrefs.GetInt("Coins") >= _price)
		{
            if (PlayerPrefs.GetString("Music") != "no")
            {
                _soundObj.clip = _success;
                _soundObj.Play();
            }
            PlayerPrefs.SetString("Location", _nameOfLocation);
			PlayerPrefs.SetString(_nameOfLocation, "Open");
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - _price);
			_coins.text = PlayerPrefs.GetInt("Coins").ToString();
			for (int i = 0; i < _buttonsToDisable.Length; i++)
				_buttonsToDisable[i].SetActive(false);

			for (int i = 0; i < _notCurrentLocationButtons.Length; i++)
				_notCurrentLocationButtons[i].GetComponent<Image>().sprite = _unchekedButton;
			_checkedButton.SetActive(true);
			_checkedButton.transform.GetChild(0).GetComponent<Image>().sprite = _checkedButtonSprite;
	
		}
        else
        {
            if (PlayerPrefs.GetString("Music") != "no")
            {
                _soundObj.clip = _fail;
                _soundObj.Play();
            }
        }
    }
}
