using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public GameObject Button;
    public GameObject Button1;

    public void StartGame()
    {
        if ((ChoiseTeam.AnimePlayer == true || ChoiseTeam.MurlocsPlayer == true || ChoiseTeam.BoysPlayer == true) && 
            (ChoiseTeam.AnimeEnemy == true || ChoiseTeam.MurlocsEnemy == true || ChoiseTeam.BoysEnemy == true))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Button.SetActive(false);
            Button1.SetActive(true);
        }
    }
}
