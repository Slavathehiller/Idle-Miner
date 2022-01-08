using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeForge : MonoBehaviour
{
    public GameObject[] upgradeImages = new GameObject[9];
    private float MaxLvl = 9;
    private int UpgradeCost = 100;
    public Button UpgradeButton;
    public Forge forge;
    void Start()
    {

    }

    void Update()
    {
        for(int i = 0; i < MaxLvl; i++)
        {
            upgradeImages[i].SetActive(i <= forge.UpgradeLvl - 1);
        }
        UpgradeButton.enabled = Stash.CoinsCount >= getUpgradeCost() && !forge.isFusing;
        UpgradeButton.gameObject.SetActive(forge.UpgradeLvl < MaxLvl);
    }

    private int getUpgradeCost()
    {
        return (forge.UpgradeLvl + 1) * UpgradeCost;
    }

    public void Upgrade()
    {
        if (Stash.CoinsCount >= getUpgradeCost() && !forge.isFusing && forge.UpgradeLvl < MaxLvl)
        {
            Stash.CoinsCount -= getUpgradeCost();
            forge.Upgrade();
        }
    } 

}
