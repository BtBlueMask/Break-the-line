using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHanler : MonoBehaviour
{
    #region ----- READ THIS: SCENE LIST -----
    /* Scenes in game (exact spelling)
    
    Gameplay: "Main"
    Menu: "Menu"
    Game over: "End"

    !! NOTE 

    OnQuit is de functie om de application af te sluiten.

    */
    #endregion

    public void LoadGameplay()
    {
        Debug.Log("gameplayPressed");
        SceneManager.LoadScene("Main");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadgameOver()
    {
        SceneManager.LoadScene("End");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
