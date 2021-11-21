using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStorage : MonoBehaviour
{
    public GameObject storagePanel;
    public GameObject resourcePanel;
    public GameObject controllPanel;
    public GameObject interfacePanel;
    private void OnMouseDown()
    {
	    storagePanel.SetActive(true);
	    resourcePanel.SetActive(false);
        controllPanel.SetActive(false);
        interfacePanel.SetActive(false);
    }
}
