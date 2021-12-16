using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchWindows : MonoBehaviour
{
    public GameObject ShowedPanel;
    public GameObject HidingPanel;

    public void OnMouseDown()
    {
        if (ShowedPanel != null)
            ShowedPanel.SetActive(true);
        if (HidingPanel != null)
            HidingPanel.SetActive(false);
    }
}
