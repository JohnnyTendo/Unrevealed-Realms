using System;
using System.IO;
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
    PlayerController player;

    private void Awake()
    {
        stack = new Stack<KeyValuePair<Enumerators.Action, KeyCode>>();
        StartNew();
        player = gameObject.GetComponent<PlayerController>();
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


    public void ExportBinding(string _playerPostfix)
    {
        string path = Application.persistentDataPath + "\\Player" + _playerPostfix + ".bdg";
        StreamWriter sw = new StreamWriter(path);
        string data = String.Empty;
        int i = 0;
        foreach (KeyValuePair<Enumerators.Action, KeyCode> bind in binding)
        {
            data += (int)bind.Key + ":" + (int)bind.Value;
            i++;
            if (i != binding.Count)
                data += "|";
        }
        //Crypt Begin
        System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
        byte[] bytes = enc.GetBytes(data);
        string encoded = Convert.ToBase64String(bytes);

        //Crypt End
        sw.WriteLine(encoded);
        sw.Close();
    }

    public void ImportBinding()
    {
        string _playerPostfix = player.postfix;
        string path = Application.persistentDataPath + "\\Player" + _playerPostfix + ".bdg";
        StreamReader sr = new StreamReader(path);
        string raw = sr.ReadLine();
        sr.Close();
        //DeCrypt Begin
        byte[] bytes = Convert.FromBase64String(raw);
        System.Text.ASCIIEncoding dec = new System.Text.ASCIIEncoding();
        string data = dec.GetString(bytes);

        //DeCrypt End
        int i = 0;
        string[] rawData = data.Split('|');
        foreach (string set in rawData)
        {
            string[] _data = set.Split(':');
            i++;
            if (i != binding.Count)
            {
                Enumerators.Action _action = (Enumerators.Action)Convert.ToInt32(_data[0]);
                KeyCode _keyCode = (KeyCode)Convert.ToInt32(_data[1]);
                binding[_action] = _keyCode;
                Helper();
            }
        }
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
