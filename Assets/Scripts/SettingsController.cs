﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    #region Singleton
    public static SettingsController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    #region Graphics
    bool isFullscreen;
    public float mainQuality { get; set; }
    public float ambienteQuality { get; set; }
    public float dayBrightness { get; set; }
    public float nightBrightness { get; set; }
    #endregion

    #region Sounds
    public float masterVolume { get; set; }
    bool masterIsMuted;
    public float musicVolume { get; set; }
    bool musicIsMuted;
    public float sfxVolume { get; set; }
    bool sfxIsMuted;
    #endregion

    #region Gameplay
    public float difficulty { get; set; }
    bool isShowingTips;
    bool isSplittscreen;

    #endregion

    #region Controls
    public PlayerController[] playerControllers;
    #endregion

    private void Start()
    {

    }

    public void StillToAssign(float _value)
    {
        isFullscreen = ValueToBool(_value);
        masterIsMuted = ValueToBool(_value);
        musicIsMuted = ValueToBool(_value);
        sfxIsMuted = ValueToBool(_value);
        isShowingTips = ValueToBool(_value);
        isSplittscreen = ValueToBool(_value);

    }

    public void SetControl(int player)
    {
        playerControllers[player - 1].keybinder.StartListening();
    }

    bool ValueToBool(float _value)
    {
        if (_value > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
