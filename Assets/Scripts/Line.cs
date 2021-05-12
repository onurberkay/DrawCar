using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float thickness;
    public float bodyThickness;
    public Material mat;
    private LineRenderer linerenderer;
    private List<Vector3> points;
    private List<Vector3> pointsForBody;
    public Canvas canvas;
    public GameObject bodyGenerator;
    BodyGenerator bodyScript;
    public Vector3 offset;
    public int scale;
    private RectTransform panel;
    private bool once = false;
    private Vector2 point;
    // Start is called before the first frame update
    void Start()
    {
        linerenderer = this.gameObject.GetComponent<LineRenderer>();
        linerenderer.startWidth = thickness;
        linerenderer.endWidth = thickness;
        linerenderer.material = mat;
        linerenderer.useWorldSpace = false;
        points = new List<Vector3>();
        pointsForBody = new List<Vector3>();
        bodyScript = bodyGenerator.GetComponent<BodyGenerator>();
        panel = this.gameObject.GetComponent<RectTransform>();
        panel.localPosition = new Vector3(0, -Screen.height / 3, 0);
        panel.sizeDelta = new Vector2(Screen.width * 0.9f, Screen.height / 3f*0.9f) ;
        //.rect.height = Screen.height / 6;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                panel.transform as RectTransform,
                Input.mousePosition, canvas.worldCamera,
                out point);
            if (RectTransformUtility.RectangleContainsScreenPoint(panel.transform as RectTransform, Input.mousePosition, canvas.worldCamera))
            {
                points.Add(new Vector3(((panel.transform.TransformPoint(point) - panel.transform.position) * scale).z, ((panel.transform.TransformPoint(point) - panel.transform.position) * scale).y, ((panel.transform.TransformPoint(point) - panel.transform.position) * scale).x));
                pointsForBody.Add(new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / (Screen.height / 2), 24));
                UpdatePoints();
                once = true;
                
                
            }
            else
            {
                if (once)
                {
                    bodyScript.SetPoints(pointsForBody.ToArray());
                    points.Clear();
                    pointsForBody.Clear();
                    once = false;
                }
            }
            
        }
        else
        {
            bodyScript.SetPoints(pointsForBody.ToArray());
            points.Clear();
            pointsForBody.Clear();
        }
    }

    private void UpdatePoints()
    {
        linerenderer.positionCount = points.Count;
        linerenderer.SetPositions(points.ToArray());
        
    }

}
