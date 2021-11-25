using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private Sprite button, pressed;
    public bool music;

    private Image _img;
    private float _yPos;
    private Transform _child;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        _img = GetComponent<Image>();
        _child = transform.GetChild(0).transform;

        if (music)
        {
            if (PlayerPrefs.GetString("Mysic") != "no")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                _child = transform.GetChild(1).transform;
            }
        }
    }

    private void OnMouseDown()
    {
        _img.sprite = pressed;
        _yPos = _child.localPosition.y;
        _child.localPosition = new Vector3(_child.localPosition.x, _yPos, _child.localPosition.z);


    }
    private void OnMouseUp()
    {
        _img.sprite = button;
        _child.localPosition = new Vector3(_child.localPosition.x, 0, _child.localPosition.z);

    }
    void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Play":
                string scene = PlayerPrefs.HasKey("Study") ? "game" : "study";//если плауер с ключом стади тогда преходим на гаме
                StartCoroutine(loadScene("game"));
                break;
            case "Replay":
                StartCoroutine(loadScene("game"));
                break;
            case "Home":
                StartCoroutine(loadScene("main"));
                break;
            case "How To":
                StartCoroutine(loadScene("study"));
                break;
            case "Shop":
                StartCoroutine(loadScene("shop"));
                break;
            case "Close":
                StartCoroutine(loadScene("main"));
                break;
            case "Music":
			_child.gameObject.SetActive (false);
			if (PlayerPrefs.GetString ("Music") != "no") { // Музыка сейчас играет и мы можем её выключить
				PlayerPrefs.SetString ("Music", "no");
				_child = transform.GetChild (1).transform;
			} else {
				PlayerPrefs.DeleteKey ("Music");
				_child = transform.GetChild (0).transform;
			}
			_child.gameObject.SetActive (true);
			break;
        }
    }
    IEnumerator loadScene (string scene)
    {
        float fadeTime = Camera.main.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene);
    }
}
