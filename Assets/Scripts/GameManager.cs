using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int alignedShipsCount = 0;
    public int totalShipsToWin; // Set this in the inspector based on the level

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
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
}
