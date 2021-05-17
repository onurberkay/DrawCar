using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow;
    public GameObject body;
    public float followSpeed;
    public Vector3 offset;
    public float back;
    public float backSpeed;
    private GameObject cam;
    private Renderer rendererBody;
    private Rigidbody followRB;
    private float camFirstX;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;

        rendererBody = body.GetComponent<Renderer>();
        followRB = follow.GetComponent<Rigidbody>();
        camFirstX = cam.transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam.transform.position = new Vector3( Mathf.Lerp(cam.transform.position.x, offset.x+camFirstX + followRB.velocity.magnitude * back,backSpeed), Mathf.Lerp( cam.transform.position.y,offset.y+rendererBody.bounds.center.y,followSpeed), Mathf.Lerp(cam.transform.position.z, offset.z+rendererBody.bounds.center.z, followSpeed));

        //temp.transform.position = cam.transform.position;
        //temp.transform.LookAt(follow.transform,Vector3.up);
        //cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, temp.transform.rotation.eulerAngles.y, cam.transform.rotation.eulerAngles.z);
        
    }
}
