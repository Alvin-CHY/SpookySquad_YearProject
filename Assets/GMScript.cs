using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public GameObject startScreenUI;
    public GameObject player;

    void Start()
    {
        player.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startScreenUI.SetActive(false); // hide menu
        player.SetActive(true);         // enable gameplay
        Time.timeScale = 1f;            // resume game
    }
}
