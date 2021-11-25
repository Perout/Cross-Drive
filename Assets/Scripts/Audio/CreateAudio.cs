using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudio : MonoBehaviour
{
	[SerializeField] private GameObject music;

	private void Start()
	{
		if (GameObject.Find("Audio Cntrl(Clone)") == null)
			Instantiate(music, new Vector3(0, 0, 0), Quaternion.identity);
	}
}
