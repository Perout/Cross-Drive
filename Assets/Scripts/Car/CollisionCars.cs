
using UnityEngine;

[ RequireComponent(typeof(MoveCar))]
public class CollisionCars : MonoBehaviour
{
	[SerializeField] private GameObject explode;
	public static bool lose = false;
	private bool onceStop;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player" && !onceStop)
		{
			lose = true;
			onceStop = true;
			gameObject.GetComponent<MoveCar>().speed = 0f;
			other.gameObject.GetComponent<MoveCar>().speed = 0f;
			gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * -1000);

			// Взрыв
			if (gameObject.transform.position.x < other.gameObject.transform.position.x)
			{
				Vector3 pos = Vector3.Lerp(gameObject.transform.position, other.transform.position, 0.5f);
				Instantiate(explode, new Vector3(pos.x, 2.7f, pos.z), Quaternion.identity);
			}
		}
	}
}
