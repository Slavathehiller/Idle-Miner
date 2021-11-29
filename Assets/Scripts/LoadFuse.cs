using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFuse : MonoBehaviour
{
    public GameObject fusePanel;
    public GameObject selfPanel;

    void OnMouseDown()
    {
        fusePanel.SetActive(true);
        selfPanel.SetActive(false);
    }
}
