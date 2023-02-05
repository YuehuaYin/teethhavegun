using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public void OnStartButt()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void OnExitButt()
    {
        Application.Quit();
    }
}
