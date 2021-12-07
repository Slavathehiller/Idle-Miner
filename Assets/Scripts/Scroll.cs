using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject ScrollingObject;


    public float highTop = -6.5f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ScrollUp()
    {
        if (ScrollingObject.gameObject.transform.position.y > highTop) 
        { 
            ScrollingObject.transform.Translate(new Vector3(0, -5), Space.World);
        }
    }

    public void ScrollDown()
    {
        ScrollingObject.transform.Translate(new Vector3(0, 5), Space.World);
    }
}
