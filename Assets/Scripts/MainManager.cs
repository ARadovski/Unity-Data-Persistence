using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    
    public int highScore;
    public string playerName;
    public string highPlayerName;

    private string nameField;

    private Canvas canvas;

    private void Awake() {

        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // nameField = canvas.transform.Find("NameInputField").GetComponent<InputField>().text;
        // Debug.Log(nameField);
    }

    private void Start() 
    {
        playerName = nameField;
    }

    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    public void SetPlayerName(){
        
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        nameField = canvas.transform.Find("NameInputField").GetComponent<InputField>().text;

        playerName = nameField;
    }
}
