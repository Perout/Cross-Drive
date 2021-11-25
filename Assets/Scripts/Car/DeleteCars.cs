using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCars : MonoBehaviour
{
    public static int _countCars;
    private void Start()
    {
        _countCars = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            if (!CollisionCars.lose)
            {
                _countCars++;
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            }
            
            Destroy(other.gameObject);
        }
    }
}
