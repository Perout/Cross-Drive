using System.Collections;

using UnityEngine;

public class AudioCntrl : MonoBehaviour
{
	private bool _play;

	private void Start()
	{
		DontDestroyOnLoad(transform.gameObject);
		StartCoroutine(horn());
	}

	private void Update()
	{
		if (PlayerPrefs.GetString("Music") != "no" && !_play)
		{
			GetComponent<AudioSource>().Play();
			_play = true;
		}
		else if (PlayerPrefs.GetString("Music") == "no" && _play)
		{
			GetComponent<AudioSource>().Pause();
			_play = false;
		}
	}

	IEnumerator horn()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(12f, 22f));
			if (PlayerPrefs.GetString("Music") != "no")
				transform.GetChild(0).GetComponent<AudioSource>().Play();
		}
	}
}
