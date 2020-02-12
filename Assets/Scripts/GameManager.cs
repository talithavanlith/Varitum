using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool inPlay = true;
    public static bool soundEnabled, musicEnabled;
    private static playerController staticPlayer;
    //public playerController player;

    private static Vector3 currentCheckpoint;
    private static int currentCheckpointNum;
    private const int NumCheckpoints = 10;

    public Slider progressSlider;
    private static Slider staticProgressSlider;


    void Start()
    {
        soundEnabled = true;
        musicEnabled = true;
        Time.timeScale = 1;

        //staticPlayer = player;
        //staticPlayer.gameObject.SetActive(false);

        staticProgressSlider = progressSlider;
    }

    public static void SetCheckpointPosition(Vector3 position, int checkpointNum)
    {
        currentCheckpoint = position;
        currentCheckpointNum = checkpointNum;
        if (staticProgressSlider)
            staticProgressSlider.value = 100f * currentCheckpointNum / (float)NumCheckpoints;
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
