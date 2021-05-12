using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class BodyGenerator : MonoBehaviour
{
    public Vector3 startPosition;
    private bool start = true;
    public float speed;
    public float thickness;
    public float offSetX;
    public float offSetY;
    public Material mat;
    public PhysicMaterial phyMat;
    public GameObject wheelOne;
    public GameObject wheelTwo;
    public GameObject body;
    public Camera cam;
    private Rigidbody bodyRB;
    private MeshFilter meshFilter;
    private Mesh mesh;
   

    public float scale;
    private List<int> triangles;
    private List<Vector3> vertices;
    private List<SphereCollider> colliders;
    private SphereCollider tempCollider;

    private bool once = true;

    private Renderer bodyRenderer;
    public float drawHeight;

    public float scanSize;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);

        
        bodyRB = body.GetComponent<Rigidbody>();
        meshFilter = body.GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        triangles = new List<int>();
        vertices = new List<Vector3>();
        colliders = new List<SphereCollider>();
        bodyRenderer = body.GetComponent<Renderer>();

        //
        

        
    }



    public void SetPoints(Vector3[] points)
    {
        Profiler.BeginSample("MyPieceOfCode");
        
        
        Vector3 temp;
        Vector3 bodyPosition;
        //points = new Vector3[] { new Vector3(1,0,0), new Vector3(6,0, 0), new Vector3(10, 0, 0), new Vector3(20, 0, 0) };
        if (points.Length > 5)
        {
            
            bodyRB.velocity = Vector3.zero;
            bodyRB.Sleep();
            
            bodyPosition = body.transform.position;
            if (once)
            {
                DestroyImmediate(body.GetComponent<SphereCollider>());
                once = false;
            }
            //points = Smooth(points);
            triangles.Clear();
            vertices.Clear();
            for(int i = 0; i < colliders.Count; i++)
            {
                Destroy(colliders[i]);
            }
            colliders.Clear();
            
            

            

            for (int i = 0; i < points.Length-1; i++)
            {
                temp = new Vector3(points[i].x * scale + offSetX, points[i].y * scale + offSetY, 0);

                tempCollider = body.AddComponent<SphereCollider>();
                tempCollider.center = temp;
                tempCollider.radius = thickness;
                tempCollider.material = phyMat;
                colliders.Add(tempCollider);
                vertices.Add(temp + thickness*Vector3.down);
                vertices.Add(temp + thickness * Vector3.left);
                vertices.Add(temp + thickness * Vector3.up);
                vertices.Add(temp + thickness * Vector3.right);


            }
           

            mesh = new Mesh();
            
            mesh.SetVertices(vertices.ToArray());
            for(int i = 0; i < vertices.Count-8; i+=4)
            {

                triangles.Add(i);
                triangles.Add(i + 7);
                triangles.Add(i + 2);

                triangles.Add(i);
                triangles.Add(i + 6);
                triangles.Add(i + 2);

                triangles.Add(i);
                triangles.Add(i + 5);
                triangles.Add(i + 2);

                triangles.Add(i);
                triangles.Add(i + 4);
                triangles.Add(i + 2);

                ////
                triangles.Add(i+1);
                triangles.Add(i + 7);
                triangles.Add(i + 3);

                triangles.Add(i + 1);
                triangles.Add(i + 6);
                triangles.Add(i + 3);

                triangles.Add(i + 1);
                triangles.Add(i + 5);
                triangles.Add(i + 3);

                triangles.Add(i + 1);
                triangles.Add(i + 4);
                triangles.Add(i + 3);


                //Reverse

                triangles.Add(i+2);
                triangles.Add(i + 7);
                triangles.Add(i );

                triangles.Add(i+2);
                triangles.Add(i + 6);
                triangles.Add(i );

                triangles.Add(i+2);
                triangles.Add(i + 5);
                triangles.Add(i );

                triangles.Add(i+2);
                triangles.Add(i + 4);
                triangles.Add(i );

                ////
                triangles.Add(i +3);
                triangles.Add(i + 7);
                triangles.Add(i + 1);

                triangles.Add(i + 3);
                triangles.Add(i + 6);
                triangles.Add(i + 1);

                triangles.Add(i + 3);
                triangles.Add(i + 5);
                triangles.Add(i + 1);

                triangles.Add(i + 3);
                triangles.Add(i + 4);
                triangles.Add(i + 1);




                /*/////////////////
                triangles.Add(i);
                triangles.Add(i + 1);
                triangles.Add(i + 2);

                triangles.Add(i);
                triangles.Add(i + 2);
                triangles.Add(i + 3);


                

                ////reverse
                triangles.Add(i+2);
                triangles.Add(i + 1);
                triangles.Add(i);

                triangles.Add(i+3);
                triangles.Add(i + 2);
                triangles.Add(i );
                */

                /////////////////////////////////
                triangles.Add(i);
                triangles.Add(i+5);
                triangles.Add(i+6);

                triangles.Add(i);
                triangles.Add(i+6);
                triangles.Add(i+7);

                triangles.Add(i);
                triangles.Add(i+5);
                triangles.Add(i+4);

                triangles.Add(i);
                triangles.Add(i+4);
                triangles.Add(i+7);

                triangles.Add(i);
                triangles.Add(i + 6);
                triangles.Add(i + 4);

                triangles.Add(i);
                triangles.Add(i + 5);
                triangles.Add(i + 7);


                /////////
                triangles.Add(i+1);
                triangles.Add(i + 5);
                triangles.Add(i + 6);

                triangles.Add(i+1);
                triangles.Add(i + 6);
                triangles.Add(i + 7);

                triangles.Add(i+1);
                triangles.Add(i + 5);
                triangles.Add(i + 4);

                triangles.Add(i+1);
                triangles.Add(i + 4);
                triangles.Add(i + 7);

                triangles.Add(i+1);
                triangles.Add(i + 6);
                triangles.Add(i + 4);

                triangles.Add(i+1);
                triangles.Add(i + 5);
                triangles.Add(i + 7);
                /////////
                triangles.Add(i + 2);
                triangles.Add(i + 5);
                triangles.Add(i + 6);

                triangles.Add(i + 2);
                triangles.Add(i + 6);
                triangles.Add(i + 7);

                triangles.Add(i + 2);
                triangles.Add(i + 5);
                triangles.Add(i + 4);

                triangles.Add(i + 2);
                triangles.Add(i + 4);
                triangles.Add(i + 7);

                triangles.Add(i + 2);
                triangles.Add(i + 6);
                triangles.Add(i + 4);

                triangles.Add(i + 2);
                triangles.Add(i + 5);
                triangles.Add(i + 7);

                /////////
                triangles.Add(i + 3);
                triangles.Add(i + 5);
                triangles.Add(i + 6);

                triangles.Add(i + 3);
                triangles.Add(i + 6);
                triangles.Add(i + 7);

                triangles.Add(i + 3);
                triangles.Add(i + 5);
                triangles.Add(i + 4);

                triangles.Add(i + 3);
                triangles.Add(i + 4);
                triangles.Add(i + 7);

                triangles.Add(i + 3);
                triangles.Add(i + 6);
                triangles.Add(i + 4);

                triangles.Add(i + 3);
                triangles.Add(i + 5);
                triangles.Add(i + 7);
                ////REVERSE
                triangles.Add(i + 7);
                triangles.Add(i + 4);
                triangles.Add(i);

                triangles.Add(i + 4);
                triangles.Add(i + 5);
                triangles.Add(i);

                triangles.Add(i + 7);
                triangles.Add(i + 6);
                triangles.Add(i);

                triangles.Add(i + 6);
                triangles.Add(i + 5);
                triangles.Add(i);

                triangles.Add(i + 4);
                triangles.Add(i + 6);
                triangles.Add(i);

                triangles.Add(i+7);
                triangles.Add(i + 5);
                triangles.Add(i);

                /////////
                triangles.Add(i + 7);
                triangles.Add(i + 4);
                triangles.Add(i+1);

                triangles.Add(i + 4);
                triangles.Add(i + 5);
                triangles.Add(i+1);

                triangles.Add(i + 7);
                triangles.Add(i + 6);
                triangles.Add(i+1);

                triangles.Add(i + 6);
                triangles.Add(i + 5);
                triangles.Add(i+1);

                triangles.Add(i + 4);
                triangles.Add(i + 6);
                triangles.Add(i+1);

                triangles.Add(i + 7);
                triangles.Add(i + 5);
                triangles.Add(i + 1);
                /////////
                triangles.Add(i + 7);
                triangles.Add(i + 4);
                triangles.Add(i + 2);

                triangles.Add(i + 4);
                triangles.Add(i + 5);
                triangles.Add(i + 2);

                triangles.Add(i + 7);
                triangles.Add(i + 6);
                triangles.Add(i + 2);

                triangles.Add(i + 6);
                triangles.Add(i + 5);
                triangles.Add(i + 2);

                triangles.Add(i + 4);
                triangles.Add(i + 6);
                triangles.Add(i + 2);

                triangles.Add(i + 7);
                triangles.Add(i + 5);
                triangles.Add(i + 2);
                /////////
                triangles.Add(i + 7);
                triangles.Add(i + 4);
                triangles.Add(i + 3);

                triangles.Add(i + 4);
                triangles.Add(i + 5);
                triangles.Add(i + 3);

                triangles.Add(i + 7);
                triangles.Add(i + 6);
                triangles.Add(i + 3);

                triangles.Add(i + 6);
                triangles.Add(i + 5);
                triangles.Add(i + 3);

                triangles.Add(i + 4);
                triangles.Add(i + 6);
                triangles.Add(i + 3);

                triangles.Add(i + 7);
                triangles.Add(i + 5);
                triangles.Add(i + 3);

            }
            
            mesh.SetTriangles(triangles.ToArray(), 0);
           // mesh.RecalculateBounds();
           // mesh.RecalculateNormals();
            //mesh.RecalculateTangents();
            mesh.Optimize();
            mesh.OptimizeIndexBuffers();
            mesh.OptimizeReorderVertexBuffer();
            meshFilter.mesh = mesh;


            



            body.transform.rotation = Quaternion.Euler(0,-90,0);
            if (start)
            {
                body.transform.position = startPosition;
                bodyRB.isKinematic = false;
                start = false;
            }
            else
            {
                body.transform.position = new Vector3(bodyPosition.x, Scan(bodyRenderer.bounds.size, bodyPosition) + drawHeight, bodyPosition.z - bodyRenderer.bounds.size.z / 2);
            }
            


            wheelOne.transform.localPosition = colliders[0].center ;
            wheelTwo.transform.localPosition = colliders[colliders.Count - 1].center;
            colliders[0].radius = 0.3f;
            colliders[colliders.Count - 1].radius = 0.3f;
            //bodyRB.centerOfMass = Vector3.down*Mathf.Abs( bodyRenderer.bounds.size.y);
            bodyRB.ResetCenterOfMass();
        }
        Profiler.EndSample();
    }

    Vector3[] Smooth(Vector3[] points)
    {
        List<Vector3> temp= new List<Vector3>();
        List<Vector3> simp = new List<Vector3>();
       
        for (int i = 1; i < points.Length-1; i++)
        {
            temp.Add(points[i]);
        }

        //LineUtility.Simplify(temp,0.01f,simp);

        
        return temp.ToArray();
    }
    
    float Scan(Vector3 size,Vector3 startPoint)
    {
        RaycastHit hit;
        int layerMask = 1 << 10;
        float maxHeight = -100;
        startPoint += 100*Vector3.up - size.magnitude*Vector3.left;
        for(float i = 0; i < size.magnitude*2; i += scanSize)
        {
            if(Physics.Raycast(startPoint+i*Vector3.right,Vector3.down,out hit, 200, layerMask))
            {
                if (hit.transform.gameObject.CompareTag("Way"))
                {
                    if (maxHeight < hit.point.y) {
                        maxHeight = hit.point.y;
                    }
                }
            }
        }
        Debug.Log(maxHeight);
        return maxHeight+1;
    }


}
