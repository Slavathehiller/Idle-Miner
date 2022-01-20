using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildBridge : MonoBehaviour
{
    public GameObject Bridge_Object;
    public GameObject SpriteStorage;
    public GameObject Cart;
    private BoxCollider2D boxCollider;
    public Text buildPrice;
    public GameObject Upgrade_Button;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (EventSystem.current.currentSelectedGameObject?.tag == "UI")
            {
                return;
            }
        }
        Stash.CoinsCount -= BuildPrice();
        Bridge_Object.GetComponent<SpriteRenderer>().sprite = SpriteStorage.GetComponent<Sprites>().Builded_Bridge;
        Cart.SetActive(true);
        Upgrade_Button.SetActive(true);
        Destroy(gameObject);
    }

    private int BuildPrice()
    {
        return Cart.GetComponent<Cart>().CartNumber * 8;
    }


    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        buildPrice.text = BuildPrice().ToString();
    }

    private void Update()
    {
        int price = BuildPrice();
        if(price <= Stash.CoinsCount)
        {
            boxCollider.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteStorage.GetComponent<Sprites>().Build_Enabled;
        }
        else
        {
            boxCollider.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteStorage.GetComponent<Sprites>().Build_Disabled;
        }
        
    }
}
