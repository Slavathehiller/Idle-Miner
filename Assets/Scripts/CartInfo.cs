using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CartInfo : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (EventSystem.current.currentSelectedGameObject?.tag == "UI")
            {
                return;
            }
        }
        Industry.ChoosenCartindex = cart.CartNumber;
        CartInfoPanel.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Industry.ChoosenCartindex = cart.CartNumber;
        CartInfoPanel.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Industry.ChoosenCartindex = cart.CartNumber;
        CartInfoPanel.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Industry.ChoosenCartindex = cart.CartNumber;
        CartInfoPanel.SetActive(true);
    }
}
