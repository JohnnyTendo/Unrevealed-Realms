using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeyBinder : MonoBehaviour
{
//Can probably be removed
    [SerializeField]
    public List<Enumerators.Action> helperList;
//Can probably be removed
    [SerializeField]
    public List<KeyCode> helperList2;

    public Dictionary<Enumerators.Action, KeyCode> binding = new Dictionary<Enumerators.Action, KeyCode>()
    {
        { Enumerators.Action.up, KeyCode.W },
        { Enumerators.Action.down, KeyCode.S },
        { Enumerators.Action.confirm, KeyCode.Return },
        { Enumerators.Action.cancel, KeyCode.Escape },
        { Enumerators.Action.start, KeyCode.Escape }
    };

    Stack<KeyValuePair<Enumerators.Action, KeyCode>> stack;
    public bool isListening = false;
    int index = 0;

    private void Awake()
    {
        stack = new Stack<KeyValuePair<Enumerators.Action, KeyCode>>();
        StartNew();
    }

    public void StartListening()
    {
        isListening = true;
        Debug.Log(name + " is now listening");
    }

    void Update()
    {
        if (isListening && Input.anyKeyDown)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    if(stack.Count > 0)
                    {
                        KeyValuePair<Enumerators.Action, KeyCode> temp = stack.Pop();
                        Rebind(temp.Key, kcode);
                    }
                    else
                    {
                        isListening = false;
                        StartNew();
                        Helper();
                    }
                }
            }
        }
    }

    void StartNew()
    {
        stack.Clear();
        foreach (var item in binding)
        {
            stack.Push(item);
        }
    }
    
    void Rebind(Enumerators.Action selected, KeyCode input)
    {
        binding[selected] = input;
        Debug.Log("Assigned " + input + " to " + selected.ToString());
    }


//Can probably be removed
    void Helper()
    {
        helperList.Clear();
        helperList2.Clear();
        foreach (var keyValue in binding)
        {
            helperList.Add(keyValue.Key);
        }
        foreach (var keyValue in binding)
        {
            helperList2.Add(keyValue.Value);
        }
    }
}
