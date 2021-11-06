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
        //gameObject.SetActive(false);
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
        boxCollider.enabled = price <= Stash.CoinsCount;
    }
}
