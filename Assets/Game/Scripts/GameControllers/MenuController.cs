using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void NewGame()
    {
        Vector3 poss = new Vector3(-2.5f, -12.30f,0);
        SceneController.Instance.LoadSceneAsync("StartScene", poss);
        PlayerPrefs.DeleteAll();
    }

    public void ContinueGame()
    {
        if(PlayerPrefs.HasKey("respawnScene"))
        {
            Vector3 poss = new Vector3(PlayerPrefs.GetInt("PosX"), PlayerPrefs.GetInt("PosY"), PlayerPrefs.GetInt("PosZ"));
            SceneController.Instance.LoadSceneAsync(PlayerPrefs.GetString("respawnScene"), poss);
        }else
        {
            NewGame();
        }
        
    }

    public void OpenCredits()
    {
        SceneController.Instance.LoadSceneAsync("FinalImprovisado",Vector3.zero);
    }

    public void BackToMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneController.Instance.LoadSceneAsync("MainMenu", Vector3.zero);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
