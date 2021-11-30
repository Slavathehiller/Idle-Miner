using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWindow : MonoBehaviour
{
    public GameObject selfPanel;
    public GameObject concurrentPanel;
    //public GameObject resourcePanel;
    //public GameObject controllPanel;
    //public GameObject interfacePanel;
    public void OnMouseDown()
    {
        if (selfPanel != null)
	        selfPanel.SetActive(true);
        if (concurrentPanel != null)
            concurrentPanel.SetActive(false);
        //resourcepanel.setactive(false);
        //   controllpanel.setactive(false);
        //interfacePanel.SetActive(false);
    }
}
