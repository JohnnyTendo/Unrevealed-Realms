using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    #region Singleton
    public static WorldGenerator instance;
    void Awake()
    {
        if (!instance)
            instance = this;
    }
    #endregion
//Not implemented and not ready yet. Not even tested
    public GameObject tilePrefab;
    Dictionary<int, Tile> world;
    PlayerController[] players;
    Vector2 lastPos;
    bool addLeft;

    public void Start()
    {
        lastPos = new Vector2();
        world = new Dictionary<int, Tile>();
        players = SettingsController.instance.playerControllers;
    }

    void GetX()
    {
        if (addLeft)
            lastPos.x = -lastPos.x;
        else
            lastPos.x = -lastPos.x + 2;
    }

    void AddTile()
    {
        Tile _tile = new Tile();
        _tile.x = (int)lastPos.x;
        _tile.value = (int)Random.Range(0, 10);
        world.Add(_tile.x, _tile);
    }
}
