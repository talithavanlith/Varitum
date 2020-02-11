using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool inPlay = true;
    public static bool soundEnabled, musicEnabled;
    private static playerController staticPlayer;
    //public playerController player;

    private static Vector3 currentCheckpoint;

    void Start()
    {
        soundEnabled = true;
        musicEnabled = true;
        Time.timeScale = 1;

        //staticPlayer = player;
        //staticPlayer.gameObject.SetActive(false);
    }

    public static void SetCheckpointPosition(Vector3 position)
    {
        currentCheckpoint = position;
    }

    public static Vector3 GetCheckpointPosition()
    {
        return currentCheckpoint;
    }

    public static void SpawnPlayer()
    {
        staticPlayer.gameObject.SetActive(true);
        inPlay = true;
    }

    public static void SetPlayer(playerController player)
    {
        staticPlayer = player;
        if (!inPlay)
            player.gameObject.SetActive(false);
    }
   
}
