using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    public GameObject fusePanel;
    public GameObject selfPanel;
    public bool isFusing;
    public int productIndex = -1;
    public int index;
    public float timeToFuse = 3;
    public GameObject SpriteStorage;

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
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteStorage.GetComponent<Sprites>().Busy_Forge;
    }

    private void FinishFuse()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteStorage.GetComponent<Sprites>().Idle_Forge;
        Stash.ResourceCount[productIndex]++;
        productIndex = -1;
    }
}
