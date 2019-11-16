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
        {
            lastPos.x = -lastPos.x;
        }
        else
        {
            lastPos.x = -lastPos.x + 16;
        }
        addLeft = !addLeft;
    }

    public void AddTile()
    {
        GameObject go = Instantiate(tilePrefab);
        Tile _tile = go.GetComponent<Tile>();
        _tile.x = (int)lastPos.x;
        _tile.value = (int)Random.Range(0, 2);
        world.Add(_tile.x, _tile);
        _tile.Activate();
        GetX();
    }
}
