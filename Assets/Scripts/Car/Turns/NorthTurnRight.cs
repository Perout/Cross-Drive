using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarLights))]
[RequireComponent(typeof(MoveCar))]
public class NorthTurnRight : MonoBehaviour
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
        if (transform.localPosition.z < 17f && carRotation != 90f)
        {
            if (carRotation >= 90f && carRotation <= 94f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 90f, 0));
                return;
            }
            eulerAngleVelocity = GetComponent<MoveCar>().speed * 8.57f;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, eulerAngleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
