using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInfo : MonoBehaviour
{
    public Cart cart;
    public GameObject CartInfoPanel;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Industry.ChoosenCartindex = cart.CartNumber;
        CartInfoPanel.SetActive(true);
    }
}
