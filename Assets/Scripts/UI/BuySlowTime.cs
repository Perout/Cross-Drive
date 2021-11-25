
using UnityEngine;
using UnityEngine.UI;

public class BuySlowTime : MonoBehaviour
{
	[SerializeField] private AudioClip _success, _fail;
	[SerializeField] private Text _count, _coins;

	private void Start()
	{
		_count.text = PlayerPrefs.GetInt("Slow Time").ToString();
	}

	void OnMouseUpAsButton()
	{
		if (PlayerPrefs.GetInt("Coins") > 100)
		{
			PlayerPrefs.SetInt("Slow Time", PlayerPrefs.GetInt("Slow Time") + 1);
			_count.text = PlayerPrefs.GetInt("Slow Time").ToString();
			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
			_coins.text = PlayerPrefs.GetInt("Coins").ToString();
			if (PlayerPrefs.GetString("Music") != "no")
			{
				gameObject.transform.GetChild(0).GetComponent<AudioSource>().clip = _success;
				gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
			}
		}
		else
		{
			if (PlayerPrefs.GetString("Music") != "no")
			{
				gameObject.transform.GetChild(0).GetComponent<AudioSource>().clip = _fail;
				gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
			}
		}
	}
}
