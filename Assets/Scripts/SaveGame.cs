using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveGame
{
    public int gold = 0;
    public DateTime timestamp = DateTime.Now;
    public TimeSpan playtime = TimeSpan.Zero;
    public int level = 0;
}
