using System.Collections;
using UnityEngine;

public class ShowLosePanel : MonoBehaviour
{
	[SerializeField] private GameObject losePanel, slowTime;
	private bool addOnce;

	void Update()
	{
		if (CollisionCars.lose && !addOnce)
		{
			addOnce = true;
			slowTime.SetActive(false);
			losePanel.SetActive(true);
		}
	}

}
