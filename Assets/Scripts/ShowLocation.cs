using System.Collections;
using UnityEngine;

public class ShowLocation : MonoBehaviour
{
   public GameObject[] _locations;

	void Start()
	{
		if (PlayerPrefs.HasKey("Location"))
		{
			for (int i = 0; i < _locations.Length; i++)
			{
				if (PlayerPrefs.GetString("Location") != _locations[i].name)
					_locations[i].SetActive(false);	
			}
		}
		else

        {
            _locations[0].SetActive(true);
			for (int i = 1; i < _locations.Length; i++)
			{
				if (PlayerPrefs.GetString("Location") != _locations[i].name)
					_locations[i].SetActive(false);
			}

		}

        Camera.main.transform.position = new Vector3(1.38f, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
}
