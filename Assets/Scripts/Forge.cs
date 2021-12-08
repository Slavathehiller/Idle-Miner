using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge : MonoBehaviour
{
    public GameObject fusePanel;
    public GameObject selfPanel;
    public bool isFusing;
    public int productIndex = -1;
    public int index;
    public float timeToFuse = 3;
    public GameObject SpriteStorage;
    public GameObject IndicatorPanel;
    public Slider ForgeIndicator;
    public Button ForgeButton;
    public Image ResourceImage;
    public Image ProductImage;

    private float timeToFinish;
    void Start()
    {
        Industry.Forges[index] = this.gameObject;
    }

    void Update()
    {
        if (!isFusing)
        {
            return;
        }
        timeToFinish -= Time.deltaTime;
        ForgeIndicator.value =  1 - timeToFinish / timeToFuse;
        isFusing = timeToFinish > 0;
        if(!isFusing)
        {
            FinishFuse();
        }
    }
   
    public void OnMouseDown()
    {
        if (isFusing) 
        {
            return;
        }
        Industry.ChoosenForgeindex = index;
        if (fusePanel != null)
            fusePanel.SetActive(true);
        if (selfPanel != null)
            selfPanel.SetActive(false);
    }
    public void StartFuse(int _productIndex)
    {
        isFusing = true;
        productIndex = _productIndex;
        timeToFinish = timeToFuse;
        ForgeButton.image.sprite = SpriteStorage.GetComponent<Sprites>().Busy_Forge;
        ResourceImage.sprite = SpriteStorage.GetComponent<Sprites>().getResourceSprites()[_productIndex - 3];
        ProductImage.sprite = SpriteStorage.GetComponent<Sprites>().getResourceSprites()[_productIndex];
        IndicatorPanel.SetActive(true);
    }

    private void FinishFuse()
    {
        ForgeButton.image.sprite = SpriteStorage.GetComponent<Sprites>().Idle_Forge;
        Stash.ResourceCount[productIndex]++;
        productIndex = -1;
        IndicatorPanel.SetActive(false);
    }
}
