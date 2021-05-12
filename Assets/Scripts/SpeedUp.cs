using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float maxSpeed;
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        Body body;
        body = other.gameObject.GetComponent<Body>();
        body.SetMaxSpeed(maxSpeed);
        body.SetForce(force);


    }
}
