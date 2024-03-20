using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene"); //eventually change TestScene to an integer variable that represents the furthest completed level
    }

    public void Quit()
    {
        Application.Quit(); //will work once version is built
    }

    public void Options()
    {
        SceneManager.LoadScene("Options Menu"); 
    }

    public void WorldMap()
    {
        SceneManager.LoadScene("Map"); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
