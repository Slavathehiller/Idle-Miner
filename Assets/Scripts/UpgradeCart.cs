using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeCart : MonoBehaviour
{
    public Sprites sprites;

    private float MaxLvl = 10;
    private int UpgradeCost = 10;

    private Button Mining_Speed_Button;
    private Slider Mining_Speed_Slider;

    private Button Moving_Speed_Button;
    private Slider Moving_Speed_Slider;

    private Button Size_Button;
    private Slider Size_Slider;

    private Button Unloading_Speed_Button;
    private Slider Unloading_Speed_Slider;

    private Button Buy_Auto_Button;
    public Image CheckIsAuto;



    private Cart getCart()
    {
        return Industry.Carts[Industry.ChoosenCartindex];
    }

    private void Start()
    {
        Mining_Speed_Button = GameObject.Find("Mining_Speed_Button").GetComponent<Button>();
        Mining_Speed_Slider = GameObject.Find("Mining_Speed_Slider").GetComponent<Slider>();
        Mining_Speed_Slider.enabled = false;

        Moving_Speed_Button = GameObject.Find("Moving_Speed_Button").GetComponent<Button>();
        Moving_Speed_Slider = GameObject.Find("Moving_Speed_Slider").GetComponent<Slider>();
        Moving_Speed_Slider.enabled = false;

        Size_Button = GameObject.Find("Size_Button").GetComponent<Button>();
        Size_Slider = GameObject.Find("Size_Slider").GetComponent<Slider>();
        Size_Slider.enabled = false;

        Unloading_Speed_Button = GameObject.Find("Unloading_Speed_Button").GetComponent<Button>();
        Unloading_Speed_Slider = GameObject.Find("Unloading_Speed_Slider").GetComponent<Slider>();
        Unloading_Speed_Slider.enabled = false;

        Buy_Auto_Button = GameObject.Find("Buy_Auto").GetComponent<Button>();
    }

    private int get_Upgrade_Mining_Speed_Cost()
    {
        return getCart().timeToLoadLvl + 1 * UpgradeCost;
    }
    public void Upgrade_Mining_Speed()
    {
        var cart = getCart();
        cart.Upgrade_Mining_Speed();
        Mining_Speed_Slider.value = cart.timeToLoadLvl / MaxLvl;
        Stash.CoinsCount -= get_Upgrade_Mining_Speed_Cost();
    }

    private int get_Upgrade_Moving_Speed_Cost()
    {
        return getCart().cartSpeedLvl + 1 * UpgradeCost;
    }
    public void Upgrade_Moving_Speed()
    {
        var cart = getCart();
        cart.Upgrade_Moving_Speed();
        Moving_Speed_Slider.value = cart.cartSpeedLvl / MaxLvl;
        Stash.CoinsCount -= get_Upgrade_Moving_Speed_Cost();
    }

    private int get_Upgrade_Size_Cost()
    {
        return getCart().cartCapacityLvl + 1 * UpgradeCost;
    }
    public void Upgrade_Size()
    {
        var cart = getCart();
        cart.Upgrade_Size();
        Size_Slider.value = cart.cartCapacityLvl / MaxLvl;
        Stash.CoinsCount -= get_Upgrade_Size_Cost();
    }

    private int get_Upgrade_Unloading_Speed_Cost()
    {
        return getCart().timeToUnloadLvl + 1 * UpgradeCost;
    }
    public void Upgrade_Unloading_Speed()
    {
        var cart = getCart();
        cart.Upgrade_Unloading_Speed();
        Unloading_Speed_Slider.value = cart.timeToUnloadLvl / MaxLvl;
        Stash.CoinsCount -= get_Upgrade_Unloading_Speed_Cost();
    }
    
    private int get_Auto_Cost()
    {
        return getCart().autoCost * (getCart().CartNumber + 1);
    }
    public void Buy_Auto()
    {
        var cart = getCart();
        cart.Buy_Auto();
        CheckIsAuto.enabled = true;
        Stash.CoinsCount -= get_Auto_Cost();
    }


    private void UpdateCartInfo(Button button, Slider slider, int curlvl, int upgradeCost)
    {
        slider.value = curlvl / MaxLvl;
        button.gameObject.SetActive(curlvl < MaxLvl);

        if (button.gameObject.activeSelf)
        {
            if (upgradeCost > Stash.CoinsCount)
            {
                button.GetComponent<Image>().sprite = sprites.Upgrade_Disabled;
                button.enabled = false;
            }
            else
            {
                button.GetComponent<Image>().sprite = sprites.Upgrade_Enabled;
                button.enabled = true;
            }
        }
    }

    private void Update()
    {
        if (Industry.ChoosenCartindex > -1)
        {
            var cart = getCart();
            UpdateCartInfo(Mining_Speed_Button, Mining_Speed_Slider, cart.timeToLoadLvl, get_Upgrade_Mining_Speed_Cost());
            UpdateCartInfo(Moving_Speed_Button, Moving_Speed_Slider, cart.cartSpeedLvl, get_Upgrade_Moving_Speed_Cost());
            UpdateCartInfo(Size_Button, Size_Slider, cart.cartCapacityLvl, get_Upgrade_Size_Cost());
            UpdateCartInfo(Unloading_Speed_Button, Unloading_Speed_Slider, cart.timeToUnloadLvl, get_Upgrade_Unloading_Speed_Cost());
            CheckIsAuto.gameObject.SetActive(cart.isAuto);
            Buy_Auto_Button.gameObject.SetActive(Stash.CoinsCount >= get_Auto_Cost() && !cart.isAuto); 
        }
    }
}
