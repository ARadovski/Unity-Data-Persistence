using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    public string highPlayerName;
    public int highScore;

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
        LoadFile();
    }

    
    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveFile();
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

    public void SaveFile()
    {
        SaveData data = new SaveData();
        data.highPlayerName = MainManager.Instance.highPlayerName;
        data.highScore = MainManager.Instance.highScore;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void LoadFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
            highScore = data.highScore;
            highPlayerName = data.highPlayerName;
        }       
    }

    [System.Serializable]
    class SaveData 
    {
        public string highPlayerName;
        public int highScore;
    }
}
