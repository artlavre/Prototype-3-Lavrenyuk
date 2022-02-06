using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loads : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Prototype 4");
    }
    
    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }
}
