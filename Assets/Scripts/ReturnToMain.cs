using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public GameObject storagePanel;
    public GameObject resourcePanel;
    public GameObject controllPanel;
    public GameObject interfacePanel;
    private void OnMouseDown()
    {
	    storagePanel.SetActive(false);
	    resourcePanel.SetActive(true);
        controllPanel.SetActive(true);
        interfacePanel.SetActive(true);
    }
}
