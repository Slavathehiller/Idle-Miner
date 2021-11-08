using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public GameObject storagePanel;
    public GameObject resourcePanel;
    private void OnMouseDown()
    {
        //SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
	storagePanel.SetActive(false);
	resourcePanel.SetActive(true);
    }
}
