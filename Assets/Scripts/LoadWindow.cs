using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWindow : MonoBehaviour
{
    public GameObject selfPanel;
    public GameObject resourcePanel;
    public GameObject controllPanel;
    public GameObject interfacePanel;
    public void OnClick()
    {
	    selfPanel.SetActive(true);
	    resourcePanel.SetActive(false);
        controllPanel.SetActive(false);
        interfacePanel.SetActive(false);
    }
}
