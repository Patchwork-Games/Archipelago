using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValueHolder
{
    private static int score, playerPos;
    private static bool gameOver;

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static int PlayerPos
    {
        get
        {
            return playerPos;
        }
        set
        {
            playerPos = value;
        }
    }

    public static bool GameOver
    {
        get
        {
            return gameOver;
        }
        set
        {
            gameOver = value;
        }
    }
}
