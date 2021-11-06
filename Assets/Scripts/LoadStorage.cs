using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStorage : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Storage", LoadSceneMode.Additive);
    }
}
