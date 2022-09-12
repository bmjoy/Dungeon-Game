using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePersist : MonoBehaviour
{
    [SerializeField] ItemType _coin;

    Player _player;
    GameData _gameData = new GameData();

    void OnDisable() => Save(true);

    void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        _player = FindObjectOfType<Player>();
        Load();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Save(false);

        if (SceneManager.GetActiveScene().buildIndex == 0)
            Destroy(gameObject);
    }

    public void Load()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            _player.ItemCollection.ClearCollection();

        if (!File.Exists("SaveGame.json"))
        {
            var fs = new FileStream("SaveGame.json", FileMode.Create);
            fs.Dispose();
        }

        using (StreamReader streamReader = new StreamReader("SaveGame.json"))
        {
            if (_gameData == null)
                _gameData = new GameData();

            var b64 = streamReader.ReadToEnd();
            var plaintextBytes = System.Convert.FromBase64String(b64);
            string json = System.Text.Encoding.UTF8.GetString(plaintextBytes);

            _gameData = JsonUtility.FromJson<GameData>(json);

            for (int i = 0; i < _gameData.Coins; i++)
                _player.ItemCollection.Add(_coin);

            // _player.Health.HealthPoints = _gameData.Health;
        }        
    }

    public void Save(bool exitGame)
    {
        if (_gameData == null)
            _gameData = new GameData();

        if (exitGame)
            _gameData.Coins = _player.CoinsBeforeLevelStart;
        else
            _gameData.Coins = _player.ItemCollection.CountOf(_coin);

        _gameData.Level = SceneManager.GetActiveScene().buildIndex;

        //_gameData.Health = _player.Health.HealthPoints;

        var json = JsonUtility.ToJson(_gameData);
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(json);
        var b64 = System.Convert.ToBase64String(plainTextBytes);

        using (StreamWriter streamWriter = new StreamWriter("SaveGame.json"))
            streamWriter.Write(b64);
    } 
}