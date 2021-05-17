using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Body : MonoBehaviour
{
    public GameObject trail;
    public float trailLimit;
    public float maxSpeed;
    public float weightMaxSpeedMultiplier = 1;
    public float weightForceMultiplier = 1;
    public float force;
    public float extraGravity = 0.0f;
    private bool wheelOne = false;
    private bool wheelTwo = false;
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
        //Debug.Log(render.bounds.size.y);
        maxSpeedTemp = maxSpeed;// (render.bounds.size.y * weightMaxSpeedMultiplier);
        forceTemp = force;// * (render.bounds.size.y * weightForceMultiplier);
        if (wheelOne)
        {
            rb.AddForce(Vector3.forward * forceTemp * Time.fixedDeltaTime, ForceMode.Force);
        }
        if (wheelTwo)
        {
            rb.AddForce(Vector3.forward * forceTemp * Time.fixedDeltaTime, ForceMode.Force);
        }
        
        Vector3 newVelo = rb.velocity;
        if (rb.velocity.x > maxSpeedTemp)
        {
            newVelo.x = maxSpeedTemp;
        }
        newVelo.y += extraGravity * Time.fixedDeltaTime;
        rb.velocity = newVelo;

        if (rb.velocity.magnitude > trailLimit)
        {
            trail.SetActive(true);
        }
        else
        {
            trail.SetActive(false);
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