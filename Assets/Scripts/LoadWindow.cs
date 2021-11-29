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
    public GameObject interfacePanel;
    public void OnClick()
    {
	    selfPanel.SetActive(true);
        concurrentPanel.SetActive(false);
        //resourcepanel.setactive(false);
        //   controllpanel.setactive(false);
        interfacePanel.SetActive(false);
    }
}
