
using UnityEngine;
using UnityEngine.UI;

public class ShowCoins : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
    }

}
