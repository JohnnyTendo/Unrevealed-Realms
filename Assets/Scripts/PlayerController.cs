using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public bool isLookingRight;
    [SerializeField]
    public KeyBinder keybinder;


    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ControllListener();
        }
        Debug.Log(Input.GetAxis("Horizontal"));
    }

    private void ControllListener()
    {
        
        if (Input.GetKey(keybinder.binding[Enumerators.Action.cancel]))
        {
            Debug.Log("Cancel triggered by " + name);
        }
        if (Input.GetKey(keybinder.binding[Enumerators.Action.confirm]))
        {
            Debug.Log("confirm triggered by " + name);
        }
        if (Input.GetKey(keybinder.binding[Enumerators.Action.down]))
        {
            Debug.Log("down triggered by " + name);
        }
        if (Input.GetKey(keybinder.binding[Enumerators.Action.up]))
        {
            Debug.Log("up triggered by " + name);
        }

    }
}
