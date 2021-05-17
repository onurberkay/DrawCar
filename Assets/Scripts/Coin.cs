using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float distance;
    private float firstY;
    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        firstY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Line")){
            once = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (once)
        {
            if(transform.position.y< firstY + distance)
            {
                transform.position += speed*Vector3.up;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y+ turnSpeed, transform.rotation.eulerAngles.z);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
