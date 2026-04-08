using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    [SerializeField] List<Wave> _waves = new List<Wave>();
    [SerializeField] List<GameObject> _currentEnemies = new List<GameObject>();

    [Header("Keeps track of")]
    [Space]
    [SerializeField] private int _currentScore;
    [SerializeField] private int _highScore;
    [SerializeField] private int _currentRound;
    [Tooltip("Do not change maxRounds(3) unless it's scaleable")]
    [SerializeField] private int _maxRounds = 3;

    private void Awake()
    {

    }
    void Start()
    {
        RestartGame();
    }


    void Update()
    {
        if (_currentEnemies.Count <= 0)
        {
            _currentRound++;
            SpawnWave(_waves[_currentRound % _waves.Count]);
        }
    }

    /// <summary>
    /// This method is used to update the score by adding the scoreToAdd parameter to the _currentScore variable and then logging the updated score to the console.
    /// </summary>
    /// <param name="scoreToAdd">This parameter is used to add score to the _currentScore</param>

    #region Score save/load/update/reset
    private void SaveScore()
    {
        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            PlayerPrefs.SetInt("HighScore", _currentScore);
            PlayerPrefs.Save();
        }
    }
    private void LoadScore()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void UpdateScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
    }
    private void ResetRoundAndScore()
    {
        _currentScore = 0;
        _currentRound = -1;
    }

    #endregion

    /// <summary>
    /// Resets the necessary needs to start a new game.
    /// </summary>
    private void RestartGame()
    {
        SaveScore();
        LoadScore();
        ResetRoundAndScore();
    }

    private void SpawnWave(Wave currentwave)
    {
        for (int i = 0; i < currentwave.enemies.Count; i++)
        {
            SpawnEnemy(currentwave.enemies[i], currentwave.enemyLocations[i]);
        }
    }

    private void SpawnEnemy(GameObject currentEnemy, Vector3 offset)
    {
        GameObject go = Instantiate(currentEnemy);
        _currentEnemies.Add(go);
        go.transform.position = transform.position + offset;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        _currentEnemies.Remove(enemy);
    }
}
