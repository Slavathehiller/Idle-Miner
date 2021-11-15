using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject ScrollingObject;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ScrollUp()
    {
        if (ScrollingObject.gameObject.transform.position.y > -8.5)
            ScrollingObject.transform.Translate(new Vector3(0, -5), Space.World);
    }

    public void ScrollDown()
    {
        ScrollingObject.transform.Translate(new Vector3(0, 5), Space.World);
    }
}
