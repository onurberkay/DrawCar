using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float maxSpeed;
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            Body body;
            body = other.gameObject.GetComponent<Body>();
            body.SetMaxSpeed(maxSpeed);
            body.SetForce(force);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 50 * force, ForceMode.Impulse);
        }
        


    }
}
