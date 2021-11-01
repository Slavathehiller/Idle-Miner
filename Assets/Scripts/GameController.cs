using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   
   public int[] ResourceCount = new int[4];
   public Text CoalCountText;
   public Text IronCountText;
   public Text GoldCountText;
   public Text DiamondCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoalCountText.text = ResourceCount[0].ToString();
        IronCountText.text = ResourceCount[1].ToString();
        GoldCountText.text = ResourceCount[2].ToString();
        DiamondCountText.text = ResourceCount[3].ToString();
    }
}
