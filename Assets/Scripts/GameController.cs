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
   public Text MoneyCountText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoalCountText.text = Stash.ResourceCount[ResourceType.Coal].ToString();
        IronCountText.text = Stash.ResourceCount[ResourceType.IronOre].ToString();
        GoldCountText.text = Stash.ResourceCount[ResourceType.GoldOre].ToString();
        DiamondCountText.text = Stash.ResourceCount[ResourceType.Diamond].ToString();
        if(MoneyCountText != null)
            MoneyCountText.text = Stash.CoinsCount.ToString();
    }
}
