using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    PlayerController player;
    Transform parent;
    public float speed;
    public float direction;
    bool active = false;

    private void Update()
    {
        if (!active) return;
        speed = player.speed;
        parent.position += new Vector3(player.speed, 0, 0);

        if ((direction > -90 && player.directionInput < 0) || (direction < 90 && player.directionInput > 0))
        {
            direction += player.directionInput;
        }
    }

    public void Activate(PlayerController _player)
    {
        parent = gameObject.transform;
        player = _player;
        active = true;
    }
}
