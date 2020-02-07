using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool inPlay = true;
    public static bool soundEnabled, musicEnabled;

    void Start()
    {
        soundEnabled = true;
        musicEnabled = true;
    }

    void Update()
    {
        
    }

    public static void SpawnPlayer()
    {
        // TODO: Spawn player
        Debug.Log("Player spawn TODO");

        inPlay = true;
    }

}
