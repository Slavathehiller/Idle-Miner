using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToForge : MonoBehaviour
{
    public GameObject forgePanel;
    public GameObject selfPanel;

    void OnMouseDown()
    {
        forgePanel.SetActive(true);
        selfPanel.SetActive(false);
    }
}
