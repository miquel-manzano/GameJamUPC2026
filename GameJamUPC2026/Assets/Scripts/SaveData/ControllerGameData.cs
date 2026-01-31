using UnityEngine;
using System.IO;
public class ControllerGameData : MonoBehaviour
{
    public string saveGameFile;
    public GameData gameData = new GameData();

    private void Awake()
    {
        saveGameFile = Application.dataPath + "/gameData.json";
    }
    private void LoadData()
    {
        if (File.Exists(saveGameFile))
        {
            string content = File.ReadAllText(saveGameFile);
            gameData = JsonUtility.FromJson<GameData>(content);
        }
        else
        {
            Debug.Log("The load file doesn't exists");
        }
    }
    private void SaveData()
    {
        GameData newGameData = new GameData()
        {
             level1 = false,
             level2 = false,
             level3 = false,
             skills =
            {
                shield = false,
                rangeAttack = false,
                dash = false,
                doubleJump = false,
            }
        };
        string stringJSON = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveGameFile, stringJSON);
        Debug.Log("Save file");
    }
}
