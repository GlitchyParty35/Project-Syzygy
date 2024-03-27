using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int alignedShipsCount = 0;
    public int totalShipsToWin; // Set this in the inspector based on the level
    public GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Player == null)
        {
            Invoke("Reset", 1.5f);
        }
    }

    public void AddAlignedShip()
    {
        alignedShipsCount++;
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (alignedShipsCount >= totalShipsToWin)
        {
            Debug.Log("Win Condition Met!");
            // Trigger win state here (e.g., load next level, show win screen, etc.)
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}