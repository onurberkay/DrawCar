using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    Rigidbody parentRB;
    ParticleSystem trail;
    // Start is called before the first frame update
    void Start()
    {
        parentRB = transform.parent.gameObject.GetComponent<Rigidbody>();
        trail = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(-parentRB.velocity) ;
        
    }
}
