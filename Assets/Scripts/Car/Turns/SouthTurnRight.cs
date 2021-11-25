using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarLights))]
[RequireComponent(typeof(MoveCar))]
public class SouthTurnRight : MonoBehaviour
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
        if (transform.localPosition.z > -3.0f && carRotation != 270f)
        {
            if (carRotation >= 269f && carRotation <= 274f)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0, 270f, 0));
                return;
            }
            eulerAngleVelocity = GetComponent<MoveCar>().speed * 8.57f;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, eulerAngleVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
