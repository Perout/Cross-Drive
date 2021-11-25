using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondStep : MonoBehaviour
{
	[SerializeField] private  Text study;

	private void Start()
	{
		study.text = "Watch where the car turns";
	}

	private void OnDisable()
	{
		PlayerPrefs.SetString("Study", "Done");
		SceneManager.LoadScene("game");
	}

}
