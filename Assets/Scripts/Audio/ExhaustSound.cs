using System.Collections;
using UnityEngine;

public class ExhaustSound : MonoBehaviour
{
    public AudioClip[] _clips;
	void Start()
	{
		if (PlayerPrefs.GetString("Music") != "no")
		{
			GetComponent<AudioSource>().clip = _clips[Random.Range(0, _clips.Length)];
			GetComponent<AudioSource>().Play();
		}
	}

}
