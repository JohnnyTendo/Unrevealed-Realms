using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    #region Singleton
    public static SaveController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public SaveGame[] saveGames;
    public SaveGame activeSave;

    
    void Start()
    {
        saveGames = new SaveGame[3];
        for (int i = 0; i < 3; i++)
        {
            saveGames[i] = new SaveGame();
        }
        activeSave = saveGames[0];
    }

    public void ChangeSave(int _index)
    {
        activeSave = saveGames[_index];
    }
}
