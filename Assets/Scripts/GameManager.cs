using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool inPlay = true;
    public static bool soundEnabled, musicEnabled;
    public playerController player;
    private static playerController staticPlayer;

    void Start()
    {
        soundEnabled = true;
        musicEnabled = true;
        staticPlayer = player;
        staticPlayer.gameObject.SetActive(false);
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

}
