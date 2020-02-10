using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool inPlay = true;
    public static bool soundEnabled, musicEnabled;
    public playerController player;
    private static playerController staticPlayer;

    private static Vector3 currentCheckpoint;

    void Start()
    {
        soundEnabled = true;
        musicEnabled = true;
        staticPlayer = player;
        staticPlayer.gameObject.SetActive(false);
    }

    public static void SetCheckpointPosition(Vector3 position)
    {
        currentCheckpoint = position;
    }

    void Update()
    {
        
    }

    public static void SpawnPlayer()
    {
        // TODO: Spawn player
        Debug.Log("Player spawn TODO");

        inPlay = true;
        staticPlayer.gameObject.SetActive(true);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 200), "CHECKPOINT: " + currentCheckpoint);
    }

}
