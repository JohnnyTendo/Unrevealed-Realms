using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string postfix;
    public bool isPlaying;
    public bool isCreated = false;
    public float speed = 0;
    public float directionInput = 0;
    public bool isLookingRight;
    public int exp;
    public int lvl;
    public int expCap = 100;
    [SerializeField]
    GameObject cameraContainer;
    public Inventory inventory;
    [SerializeField]
    public KeyBinder keybinder;
    Character character;
    [SerializeField]
    GameObject avatarPrefab;

    bool isShooting = false;

    private void Start()
    {
        string _name = gameObject.name;
        postfix = _name.Substring(_name.LastIndexOf('_'));
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) ControllListener();
        speed = Input.GetAxis("Horizontal" + postfix) / SettingsController.instance.speedDivider;
        directionInput = Input.GetAxis("Vertical" + postfix) / SettingsController.instance.sightMultiplier;
    }

    private void ControllListener()
    {
        if (isPlaying)
        {
            if (Input.GetKey(keybinder.binding[Enumerators.Action.start]))
            {
                //Show inventory
                keybinder.ExportBinding(postfix);
                Debug.Log("start triggered by " + name);
            }
            if (Input.GetKey(keybinder.binding[Enumerators.Action.cancel]))
            {
                //Interact
                Debug.Log("Cancel triggered by " + name);
            }
            if (!isShooting && Input.GetKey(keybinder.binding[Enumerators.Action.confirm]))
            {
                //Fire
                Debug.Log("Player attaked with: " + Dice.Roll((int)Enumerators.Dices.W6,1));
                Debug.Log("confirm triggered by " + name);
                AddExperience(200);
                isShooting = true;
            }
            if (isShooting && !Input.GetKey(keybinder.binding[Enumerators.Action.confirm]))
            {
                //Reset Fire when button is released
                isShooting = false;
            }

        }
    }

    public void CreateAvatar()
    {
        inventory = gameObject.GetComponent<Inventory>();
        GameObject go = Instantiate(avatarPrefab, new Vector3(0,0,0), Quaternion.identity);
        character = go.GetComponent<Character>();
        character.Activate(this);
        isCreated = true;
        inventory.SetUp();
        cameraContainer.GetComponent<CameraScript>().ToggleCamera(character.gameObject);
        keybinder.ImportBinding();
    }

    public void AddExperience(int _exp)
    {
        exp += _exp;
        if (exp > expCap)
        {
            LevelUp();
            exp = 0;
            expCap *= lvl;
        }
    }

    void LevelUp()
    {
        lvl++;
        Debug.Log("Level " + lvl + " !!!");
        //TBA: Adjust Stats
        WorldGenerator.instance.AddTile();
    }
}
