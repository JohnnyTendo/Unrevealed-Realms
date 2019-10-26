using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    PlayerController[] players;
    int counter = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        players = SettingsController.instance.playerControllers;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1) return;
        foreach (PlayerController player in players)
        {
            if(!player.isPlaying && Input.GetButtonDown("Start"+ player.postfix))
            {
                Debug.Log("Start Player" + player.postfix);
                player.isPlaying = true;
            }
            if(player.isPlaying && !player.isCreated)
            {
                player.CreateAvatar();
                counter++;
            }
        }

    }
}
