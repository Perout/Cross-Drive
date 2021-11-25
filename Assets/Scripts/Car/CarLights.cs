using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public int showObject;
    private void Start()
    {
        StartCoroutine(Light());
        if (PlayerPrefs.GetString("Music") != "no")
            StartCoroutine(sound());

    }
    IEnumerator Light()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject light = gameObject.transform.GetChild(showObject).gameObject;
        while (true)
        {
            light.SetActive(!light.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }

    }
    IEnumerator sound()
    {
        GameObject s = Instantiate(GetComponent<MoveCar>().turnSignal, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(1.3f);
        Destroy(s.gameObject);
    }
}
