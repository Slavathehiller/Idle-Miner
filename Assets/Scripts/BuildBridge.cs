using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    public GameObject Bridge_Object;
    public GameObject SpriteStorage;
    public GameObject Cart;
    public int CartNumber;
    private BoxCollider2D boxCollider;

    private void OnMouseDown()
    {
        Stash.CoinsCount -= BuildPrice();
        Bridge_Object.GetComponent<SpriteRenderer>().sprite = SpriteStorage.GetComponent<Sprites>().Builded_Bridge;
        Cart.SetActive(true);
        Destroy(gameObject);
    }

    private int BuildPrice()
    {
        return CartNumber * 8;
    }


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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
