using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellResourceWindow : MonoBehaviour
{
    private int ResType;
    public Image ResImage;
    public Text AllResCount;
    public Text SellResCount;
    public Slider CountSlider;
    public GameObject Window;
    public Sprites spriteStorage;
    private long sellCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        long allCount = Stash.ResourceCount[ResType];
        sellCount = Mathf.RoundToInt(CountSlider.value * allCount);
        long restCount = allCount - sellCount;
        AllResCount.text = TextHelper.ShortNumber(restCount);
        SellResCount.text = TextHelper.ShortNumber(sellCount);
    }

    public void SellResource(int resType)
    {
        ResType = resType;
        CountSlider.value = 0;
        ResImage.sprite = spriteStorage.getResourceSprites()[resType];
        Window.SetActive(true);
    }

    public void SellResourceAmount()
    {
        Stash.CoinsCount += sellCount * Stash.ResourcePrices[ResType];
        Stash.ResourceCount[ResType] -= sellCount;
    }
}
