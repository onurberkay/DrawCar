using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public float maxSpeed;
    public float force;
    private bool wheelOne = false;
    private bool wheelTwo=false;
    private Rigidbody rb;
    private Renderer render;
    private float maxSpeedTemp;
    private float forceTemp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(render.bounds.size.y);
        maxSpeedTemp = maxSpeed / (render.bounds.size.y);
        forceTemp = force * (render.bounds.size.y);
        if (wheelOne)
        {
            rb.AddForce(Vector3.forward * forceTemp*Time.fixedDeltaTime,ForceMode.Impulse);
            if (rb.velocity.magnitude > maxSpeedTemp)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
        if (wheelTwo)
        {
            rb.AddForce(Vector3.forward * forceTemp*Time.fixedDeltaTime,ForceMode.Impulse);
            if (rb.velocity.magnitude > maxSpeedTemp)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    public void SetMaxSpeed(float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
    }

    public void SetForce(float force)
    {
        this.force = force;
    }
    public void SetWheelOne(bool value)
    {
        wheelOne = value;

    }

    public void SetWheelTwo(bool value)
    {
        wheelTwo = value;

    }
   

}
