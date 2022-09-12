using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _continueButton;

    GameData _gameData;

    void Start()
    {
        _gameData = ReadGameData();

        if (_gameData.Level != 0 && _gameData.Level != 1)
            _continueButton.SetActive(true);
    }

    GameData ReadGameData()
    {
        using (StreamReader streamReader = new StreamReader("SaveGame.json"))
        {
            var b64 = streamReader.ReadToEnd();
            var plaintextBytes = System.Convert.FromBase64String(b64);
            string json = System.Text.Encoding.UTF8.GetString(plaintextBytes);

            return JsonUtility.FromJson<GameData>(json);
        }
    }

    public void ContinueSavedGame() => SceneManager.LoadScene(_gameData.Level);

    public void StartNewGame()
    {
        ClearGameData();
        SceneManager.LoadScene("Level 1");
    }

    void ClearGameData()
    {
        _gameData.Coins = 0;

        var json = JsonUtility.ToJson(_gameData);
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(json);
        var b64 = System.Convert.ToBase64String(plainTextBytes);

        using (StreamWriter streamWriter = new StreamWriter("SaveGame.json"))
            streamWriter.Write(b64);
    }
}
