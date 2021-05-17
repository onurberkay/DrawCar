using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class PointGenerator : MonoBehaviour
{
    public string address;
    public float scale;
    public GameObject body;
    public GameObject generateBody;
    private Rigidbody rb;
    public float minSpeed=1;
    private BodyGenerator script;
    private PointData pointData;
    public float delay;
    private float delayTime;
    private int order = 0;
    private float startTime;
    //public float delay;


    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = body.GetComponent<Rigidbody>();
        script = generateBody.GetComponent<BodyGenerator>();




        if (File.Exists("assets/"+address))
        {
            Debug.Log("Point Generator: File Found");
            // Create a FileStream connected to the saveFile.
            // Set to the file mode to "Open"
            FileStream dataStream = new FileStream("assets/"+address, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();


            SurrogateSelector surrogateSelector = new SurrogateSelector();
            Vector3SerializationSurrogate vector3SS = new Vector3SerializationSurrogate();

            surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SS);
            converter.SurrogateSelector = surrogateSelector;


            // Serialize GameData into binary data 
            //  and add it to an existing input stream.
            pointData = (PointData) converter.Deserialize(dataStream) ;

            // Close the stream
            dataStream.Close();
        }
        else
        {
            Debug.Log("Point Generator: File not Found");
        }





    }

    // Update is called once per frame
    void Update()
    {
        if(pointData == null)
        {
            Debug.Log("nulllllllS");
        }
        if (Input.GetMouseButtonDown(0)&& !start)
        {
            start = true;
            startTime = Time.time;
        }
        if (start)
        {
            if (rb.velocity.magnitude < minSpeed && Time.time > delayTime)
            {
                script.SetPoints(pointData.list[Random.Range(0, pointData.list.Count)].points.ToArray());
                delayTime = delay + Time.time;
            }
            /*
            if (Time.time-startTime>pointData.times[order])
            {
                
                script.SetPoints(pointData.list[order].points.ToArray());
                Debug.Log("order:" + order+"point count"+pointData.list[order].points.Count);
                order++;
            }*/
        }
    }




}
