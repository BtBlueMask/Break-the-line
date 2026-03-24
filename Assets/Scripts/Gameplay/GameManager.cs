using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    [Header("Keeps track of")]
    [Space]
    [SerializeField] private int _currentScore;
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



    }

    private void UpdateRoundNumber()
    {
        _currentRound++;
        Debug.Log("Round: " + _currentRound);
    }
    /// <summary>
    /// This method is used to update the score by adding the scoreToAdd parameter to the _currentScore variable and then logging the updated score to the console.
    /// </summary>
    /// <param name="scoreToAdd">This parameter is used to add score to the _currentScore</param>

    #region Score save/load/update
    private void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", _currentScore);
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        _currentScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void UpdateScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        Debug.Log("Score: " + _currentScore);
    }
    #endregion

    /// <summary>
    /// Resets the necessary needs to start a new game.
    /// </summary>
    private void RestartGame()
    {
        MainScene();
        _currentScore = 0;
        _currentRound = 0;
        Debug.Log("Game Reset");
    }

    private void SpawnWave()
    {
        //Instantiate();
    }

    #region Scenes
    private void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void MainScene()
    {
       SceneManager.LoadScene("MainScene");
    }

    private void EndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
    #endregion



}
