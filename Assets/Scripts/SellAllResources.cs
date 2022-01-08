using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAllResources : MonoBehaviour
{
    public int ResType;
    public void OnClick()
    {
        Stash.CoinsCount += Stash.ResourceCount[ResType] * Stash.ResourcePrices[ResType];
        Stash.ResourceCount[ResType] = 0;
    }
}
