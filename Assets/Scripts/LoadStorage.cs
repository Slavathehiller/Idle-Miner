using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStorage : MonoBehaviour
{
    public GameObject storagePanel;
    public GameObject resourcePanel;
    private void OnMouseDown()
    {
	//UIPanel.Find("ResourcePanel").SetActive(false);
	//UIPanel.Find("StoragePanel").SetActive(true);
	storagePanel.SetActive(true);
	resourcePanel.SetActive(false);
        //SceneManager.LoadScene("Storage", LoadSceneMode.Additive);
    }
}
