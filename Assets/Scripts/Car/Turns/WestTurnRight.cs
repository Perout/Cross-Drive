using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarLights))]
[RequireComponent(typeof(MoveCar))]
public class WestTurnRight : MonoBehaviour
{
    private Rigidbody rb;
    private float eulerAngleVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<CarLights>().showObject = 0;
    }
    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        if (transform.localPosition.x > -13f && carRotation != 0f)
        {
            if (carRotation >= -1f && carRotation <= 4f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0f, 0));
                return;
            }
            eulerAngleVelocity = GetComponent<MoveCar>().speed * 8.57f;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, eulerAngleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}