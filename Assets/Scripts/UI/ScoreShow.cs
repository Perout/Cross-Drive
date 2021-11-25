
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
   [SerializeField] private Text _topRecord;
    private void OnEnable()
    {
        GetComponent<Text>().text = "Score: " + DeleteCars._countCars.ToString();
        if (PlayerPrefs.GetInt("Score") < DeleteCars._countCars)
        {
            PlayerPrefs.SetInt("Score", DeleteCars._countCars);
            _topRecord.text = "Top:" + DeleteCars._countCars.ToString();
            //если у нас большой резуальтат, то записываем
        }
        else
        {
            _topRecord.text = "Top: " + PlayerPrefs.GetInt("Score").ToString();
        }
    }
}
