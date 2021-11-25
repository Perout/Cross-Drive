using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpodeSound : MonoBehaviour
{
	private void Start()
	{
		if (PlayerPrefs.GetString("Music") != "no")
			GetComponent<AudioSource>().Play();
	}
}
