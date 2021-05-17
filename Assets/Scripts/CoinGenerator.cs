using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;
    public float gap;
    public int sizeX;
    public int sizeY;
    // Start is called before the first frame update
    void Start()
    {
        for(int x=-sizeX;x < sizeX; x++)
        {
            for(int y= -sizeY; y < sizeY; y++)
            {
                Instantiate(coin, this.gameObject.transform).transform.localPosition = new Vector3(0,x*gap,y*gap);
            }
        }
    }

  
}
