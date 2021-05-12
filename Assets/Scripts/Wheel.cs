using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{

    private Body body;
    public bool one;
    // Start is called before the first frame update
    void Start()
    {
        body = transform.parent.gameObject.GetComponent<Body>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Way"))
        {
            if (one)
            {
                body.SetWheelOne(true);
            }
            else
            {
                body.SetWheelTwo(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Way"))
        {
            if (one)
            {
                body.SetWheelOne(false);
            }
            else
            {
                body.SetWheelTwo(false);
            }
        }
    }


}
