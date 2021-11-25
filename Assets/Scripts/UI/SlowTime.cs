using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour
{
    private Text countSlow;
   [SerializeField] private Sprite active, inactive;

	private void Start()
	{
        // берем первый дочерний обьект
        countSlow = gameObject.transform.GetChild(0).transform.GetComponent<Text>();
        
        if (!PlayerPrefs.HasKey("Slow Time"))
        {
            PlayerPrefs.SetInt("Slow Time", 2);
            countSlow.text = "2";
        }
        else
            countSlow.text = PlayerPrefs.GetInt("Slow Time").ToString();

        if (PlayerPrefs.GetInt("Slow Time") == 0)
            GetComponent<Image>().sprite = inactive;
        else
            GetComponent<Image>().sprite = active;
    }

    void OnMouseDown()
	{
        if (PlayerPrefs.GetInt("Slow Time") > 0 && Time.timeScale != 0.5f)
        {
            if (PlayerPrefs.GetString("Music") != "no")
                GetComponent<AudioSource>().Play();

            PlayerPrefs.SetInt("Slow Time", PlayerPrefs.GetInt("Slow Time") - 1);
            countSlow.text = PlayerPrefs.GetInt("Slow Time").ToString();
            if (PlayerPrefs.GetInt("Slow Time") == 0)
                GetComponent<Image>().sprite = inactive;
            StartCoroutine(slow());
        }
    }

	IEnumerator slow()
	{
		Time.timeScale = 0.5f;
		yield return new WaitForSeconds(3f);
		Time.timeScale = 1f;
	}

	void OnDisable()
	{
		Time.timeScale = 1f;
	}
}
