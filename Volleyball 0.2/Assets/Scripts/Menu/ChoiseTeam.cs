using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiseTeam : MonoBehaviour
{
    public GameObject AnimeRed;
    public GameObject AnimeBlue;
    public GameObject MurlocsRed;
    public GameObject MurlocsBlue;
    public GameObject SexyRed;
    public GameObject SexyBlue;

    public static bool AnimePlayer = false;
    public static bool MurlocsPlayer = false;
    public static bool BoysPlayer = false;

    public static bool AnimeEnemy = false;
    public static bool MurlocsEnemy = false;
    public static bool BoysEnemy = false;

    public void ChoiseAnime()
    {
        Options.ListOfTeams[0] = Players.Anime;
        AnimePlayer = true;
        AnimeEnemy = false;
        MurlocsPlayer = false;
        BoysPlayer = false;
        AnimeRed.SetActive(false);
        AnimeBlue.SetActive(true);
        MurlocsBlue.SetActive(false);
        SexyBlue.SetActive(false);
    }
    public void ChoiseMurlocs()
    {
        Options.ListOfTeams[0] = Players.Murlocs;
        MurlocsPlayer = true;
        MurlocsEnemy = false;
        BoysPlayer = false;
        AnimePlayer = false;
        MurlocsRed.SetActive(false);
        MurlocsBlue.SetActive(true);
        AnimeBlue.SetActive(false);
        SexyBlue.SetActive(false);
    }
    public void ChoiseBoys()
    {
        Options.ListOfTeams[0] = Players.Boys;
        BoysPlayer = true;
        BoysEnemy = false;
        AnimePlayer = false;
        MurlocsPlayer = false;
        SexyRed.SetActive(false);
        SexyBlue.SetActive(true);
        MurlocsBlue.SetActive(false);
        AnimeBlue.SetActive(false);
    }
    public void EnemyAnime()
    {
        Options.ListOfTeams[1] = Players.Anime;
        AnimeEnemy = true;
        AnimePlayer = false;
        MurlocsEnemy = false;
        BoysEnemy = false;
        AnimeRed.SetActive(true);
        AnimeBlue.SetActive(false);
        MurlocsRed.SetActive(false);
        SexyRed.SetActive(false);
    }
    public void EnemyMurlocs()
    {
        Options.ListOfTeams[1] = Players.Murlocs;
        MurlocsEnemy = true;
        MurlocsPlayer = false;
        BoysEnemy = false;
        AnimeEnemy = false;
        MurlocsRed.SetActive(true);
        MurlocsBlue.SetActive(false);
        AnimeRed.SetActive(false);
        SexyRed.SetActive(false);
    }
    public void EnemyBoys()
    {
        Options.ListOfTeams[1] = Players.Boys;
        BoysEnemy = true;
        BoysPlayer = false;
        AnimeEnemy = false;
        MurlocsEnemy = false;
        SexyRed.SetActive(true);
        SexyBlue.SetActive(false);
        MurlocsRed.SetActive(false);
        AnimeRed.SetActive(false);
    }

}
