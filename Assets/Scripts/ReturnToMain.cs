using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
