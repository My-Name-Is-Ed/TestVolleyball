using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Options 
{
    static public Team[] ListOfTeams = new Team[] {Players.Boys, Players.Boys };
    public enum Mode
    { 
        Moving,
        Learping
    }
    public enum Enum
    { 
        zero,
        one,
        two,
        three,
        four,
        five
    }
    public enum Side
    { 
        Radiant,
        Dire
    }
    static public Options.Mode ModeOn = Options.Mode.Moving;

    static public bool ModeLine = false;

    static public float SizePlayers = 20;
    static public float SizeBall = 5;

    static public float speed = 5f;

    static public int lvlstats1 = 2;
    static public int lvlstats2 = 30;
    static public int lvlstats3 = 0;

    static public int lvlstats4 = 1;
}
public class Team
{
    public Sprite Logo;
    public string NameTeam;
    public Player[] Players;
}
public class Player
{
    public Player(string name, int PoC, int PoT, int PoF)
    {
        Name = name;
        PCatch = PoC;
        PThrow = PoT;
        PFiling = PoF;
    }
    public Sprite Face;
    public string Name;
    public int PCatch;
    public int PThrow;
    public int PFiling;
}

public class Players
{
    public static Player Dahaka = new Player("Dahaka", 88, 88, 88);
    public static Player OmniMan = new Player("OmniMan", 100, 100, 100);
    public static Player Pudge = new Player("Pudginister", 30, 30, 30);
    public static Player Sokol = new Player("Sokol", 90, 60, 100);
    public static Player Vlad = new Player("Vlad", 85, 85, 50);
    public static Player Wick = new Player("Wick", 95, 86, 80);

    static public Team Boys = new Team() { NameTeam = "Boys", Players = new Player[] { Dahaka, OmniMan, Pudge, Sokol, Vlad, Wick } };

    public static Player TD = new Player("Toody", 100, 100, 50);
    public static Player Stonk = new Player("Stonk", 70, 90, 100);
    public static Player SmallFin = new Player("SmallFin", 50, 50, 50);
    public static Player Nikky = new Player("Nikky", 70, 85, 100);
    public static Player Hamster = new Player("Hamster", 1, 1000, 1000);
    public static Player Woody = new Player("Woody", 80, 70, 50);

    static public Team Murlocs = new Team() { NameTeam = "Murlocs", Players = new Player[] { SmallFin, Stonk, Woody, Nikky, Hamster, TD } };

    public static Player Integra = new Player("Integra", 100, 80, 20);
    public static Player Albedo = new Player("Albedo", 90, 70, 70);
    public static Player Lust = new Player("Lust", 60, 80, 77);
    public static Player Ruby = new Player("Ruby", 90, 90, 90);
    public static Player Shikamaru = new Player("Shikamaru", 70, 80, 90);
    public static Player Kek = new Player("Kek", 100, 0, 0);

    static public Team Anime = new Team() { NameTeam = "Anime",  Players = new Player[] { Ruby, Albedo, Lust, Integra, Shikamaru, Kek } };

}

