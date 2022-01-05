using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text CoalCountText;
    public Text IronCountText;
    public Text GoldCountText;
    public Text DiamondCountText;
    public Text IronBarCountText;
    public Text GoldBarCountText;
    public Text BrilliantCountText;
    public Text MoneyCountText = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAmount(CoalCountText, ResourceType.Coal);
        SetAmount(IronCountText, ResourceType.IronOre);
        SetAmount(GoldCountText, ResourceType.GoldOre);
        SetAmount(DiamondCountText, ResourceType.Diamond);
        SetAmount(IronBarCountText, ResourceType.IronBar);
        SetAmount(GoldBarCountText, ResourceType.GoldBar);
        SetAmount(BrilliantCountText, ResourceType.Brilliant);
        if (MoneyCountText != null)
            MoneyCountText.text = TextHelper.ShortNumber(Stash.CoinsCount);
    }

    private void SetAmount(Text text, int resIndex)
    {
        if(text != null)
            text.text = TextHelper.ShortNumber(Stash.ResourceCount[resIndex]);
    }
}
