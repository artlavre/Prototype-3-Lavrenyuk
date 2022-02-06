using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Restart()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
