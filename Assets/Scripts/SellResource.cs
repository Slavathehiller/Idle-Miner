using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellResource : MonoBehaviour
{
    public SellResourceWindow sellResourceWindow;
    public int resType;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Sell()
    {
        sellResourceWindow.SellResource(resType);
    }
}
