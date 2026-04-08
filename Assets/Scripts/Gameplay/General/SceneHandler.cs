using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHanler : MonoBehaviour
{
    #region ----- READ THIS: SCENE LIST -----
    /* Scenes in game (exact spelling)
    
    Gameplay: "Main"
    Menu: "Menu"
    Game over: "End"
    */
    #endregion

    public void LoadGameplay()
    {
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

}
