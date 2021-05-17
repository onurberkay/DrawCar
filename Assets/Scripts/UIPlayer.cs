using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{

    private RectTransform rectTransform;
    public GameObject player;
    public float mapLength;
    // Start is called before the first frame update
    void Start()
    {        
        rectTransform = transform.parent.transform as RectTransform;
        transform.localPosition = new Vector3(-rectTransform.rect.width / 2,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3((player.transform.position.z / mapLength) * rectTransform.rect.width - rectTransform.rect.width / 2, 10,0 );

    }
}
