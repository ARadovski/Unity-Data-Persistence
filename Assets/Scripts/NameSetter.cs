using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NameSetter : MonoBehaviour
{
    InputField mainInputField;

    private MainManager mainManager;

    private void Awake() {
        mainInputField = GetComponent<InputField>();
    }

    private void Start() {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        mainInputField.onEndEdit.AddListener(delegate{mainManager.SetPlayerName();});
    }
    
}
