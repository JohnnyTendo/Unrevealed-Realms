using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    #region Singleton
    public static MenuScript instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    GameObject activePage;
    GameObject activeButton;
    GameObject activeOption;
    public int activePageIndex;
    public int activeButtonIndex;
    public int activeOptionsIndex;

    public GameObject[] pages;
    public GameObject[] buttons;
    public GameObject[] options;
    public GameObject[] saveValueLabels;

    bool optionSelected = false;


    // Start is called before the first frame update
    void Start()
    {
        activePageIndex = 0;
        activeButtonIndex = 0;
        activeOptionsIndex = 0;
        RefreshSaveSidecard();
        UpdateItemCollection(activePageIndex, pages, activePage);
        UpdateTextEffects(activeButtonIndex, buttons, activeButton);
        UpdateTextEffects(activeOptionsIndex, options, activeOption);
    }

    // Update is called once per frame
    void Update()
    {
        if (activePageIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                buttons[activeButtonIndex].GetComponent<Button>().Select();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S pressed");
                if (activeButtonIndex < buttons.Length - 1)
                {
                    activeButtonIndex++;
                    UpdateTextEffects(activeButtonIndex, buttons, activeButton);
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W pressed");
                if (activeButtonIndex >= 1)
                {
                    activeButtonIndex--;
                    UpdateTextEffects(activeButtonIndex, buttons, activeButton);
                }
            }
        }
        else if (activePageIndex == 3 && !optionSelected)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                options[activeOptionsIndex].GetComponent<Button>().Select();
                optionSelected = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S pressed");
                if (activeOptionsIndex < options.Length - 1)
                {
                    activeOptionsIndex++;
                    UpdateTextEffects(activeOptionsIndex, options, activeOption);
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W pressed");
                if (activeOptionsIndex >= 1)
                {
                    activeOptionsIndex--;
                    UpdateTextEffects(activeOptionsIndex, options, activeOption);
                }
            }
        }
        else if (activePageIndex == 3 && optionSelected)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionSelected = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S pressed");
                if (activeOptionsIndex < options.Length - 1)
                {

                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W pressed");
                if (activeOptionsIndex >= 1)
                {

                }
            }
        }
    }

    public void OnGUI()
    {
        if (activePageIndex <= 1)
        { 
            if (Event.current.type == EventType.MouseDown)
            {
                Debug.Log("Mouse pressed");
                activePageIndex++;
                UpdateItemCollection(activePageIndex, pages, activePage);
            }
        } 
    }

    #region Sidecards
    public void RefreshSaveSidecard()
    {
        saveValueLabels[0].GetComponent<Text>().text = SaveController.instance.activeSave.timestamp.ToString();
        saveValueLabels[1].GetComponent<Text>().text = SaveController.instance.activeSave.gold.ToString();
        saveValueLabels[2].GetComponent<Text>().text = SaveController.instance.activeSave.playtime.ToString();
        saveValueLabels[3].GetComponent<Text>().text = SaveController.instance.activeSave.level.ToString();
    }
    #endregion

    #region OptionsButtons
    public void GraphicsOptions()
    {
        
    }

    public void SoundsOptions()
    {
        
    }

    public void GameplayOptions()
    {
        
    }

    public void ControlsOptions()
    {
        
    }

    public void SetActiveOption()
    {

    }
    #endregion

    #region MenuButtons
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        Debug.Log("New Game started");
    }

    public void Continue()
    {
        //SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        Debug.Log("Game Continued");
    }

    public void Options()
    {
        activePageIndex = 3;
        UpdateItemCollection(activePageIndex, pages, activePage);
    }

    public void Credits()
    {
        activePageIndex = 4;
        UpdateItemCollection(activePageIndex, pages, activePage);
    }

    public void BackToMenu()
    {
        activePageIndex = 2;
        UpdateItemCollection(activePageIndex, pages, activePage);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Tools
    void UpdateTextEffects(int _index, GameObject[] _collection, GameObject _activeTarget)
    {
        _activeTarget = _collection[_index];
        for (int i = 0; i < _collection.Length; i++)
        {
            if (_collection[i] != _activeTarget)
            {
                _collection[i].GetComponent<ChangeFontScript>().Deactivate();
            }
            else
            {
                _collection[i].GetComponent<ChangeFontScript>().Activate();
            }
        }
        UpdateSideCard(_collection, _activeTarget);
    }

    void UpdateSideCard(GameObject[] _collection, GameObject _activeTarget)
    {
        for (int i = 0; i < _collection.Length; i++)
        {
            if (_collection[i] == _activeTarget)
                _collection[i].GetComponent<SideCard>().go.SetActive(true);
            else
                _collection[i].GetComponent<SideCard>().go.SetActive(false);
        }
    }

    public void UpdateItemCollection(int _index, GameObject[] _collection, GameObject _activeTarget)
    {
        _activeTarget = _collection[_index];
        for (int i = 0; i < pages.Length; i++)
        {
            if (_collection[i] != _activeTarget)
            {
                _collection[i].SetActive(false);
            }
            else
            {
                _collection[i].SetActive(true);
            }
        }
    }
    #endregion
}
