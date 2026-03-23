using UnityEngine;

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
      ResetGame();
    }

    
    void Update()
    {
        
    }

    private void UpdateRound()
    {
        _currentRound++;
        Debug.Log("Round: " + _currentRound);
    }
    /// <summary>
    /// This method is used to update the score by adding the scoreToAdd parameter to the _currentScore variable and then logging the updated score to the console.
    /// </summary>
    /// <param name="scoreToAdd">This parameter is used to add score to the _currentScore</param>
    private void UpdateScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        Debug.Log("Score: " + _currentScore);
    }
    /// <summary>
    /// Resets the necessary vars to start a new game.
    /// </summary>
    private void ResetGame()
    {
        //needs a scene id
        _currentScore = 0;
        _currentRound = 0;
        Debug.Log("Game Reset");
    }

    private void Spawn ()
    {
        //spawn logic
    }

}
