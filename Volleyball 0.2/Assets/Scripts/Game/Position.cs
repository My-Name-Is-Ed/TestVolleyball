using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Options.Enum PlayerNumber;
    public Options.Side side;

    public enum PositionHere
    { 
        None,
        Melle,
        Range
    }

    public PositionHere PH;

    public GameObject NeighborLeft;
    public GameObject NeighborMid;
    public GameObject NeighborRight;

    public GameObject BackLight;

    public GameObject Ball;

    public Player Here;

    public int StatsCatch;
    public int StatsFiling;

    private void Start()
    {
        int Player = (int)PlayerNumber;
        Here = Options.ListOfTeams[(int)side].Players[(int)PlayerNumber--];
        GetComponent<SpriteRenderer>().sprite = Here.Face;
        transform.localScale = new Vector3(Options.SizePlayers/50, Options.SizePlayers/50, 0f);
        BackLight.transform.localScale = new Vector3(Options.SizePlayers/2, Options.SizePlayers/2, 0f);

        if (PH == PositionHere.Melle)
        {
            StatsFiling = Here.PFiling / Options.lvlstats1;
            StatsCatch = Here.PCatch + Options.lvlstats2;
        }
        if (PH == PositionHere.Range)
        {
            StatsFiling = Here.PFiling + 15;
            StatsCatch = Here.PCatch;
        }
        if (PH == PositionHere.None)
        {
            StatsFiling = Here.PFiling + Options.lvlstats3;
            StatsCatch = Here.PCatch + Options.lvlstats3;
        }
    }
    public void NewRound()
    {
        if (Ball.GetComponent<NewBall>().lastGoal != Ball.GetComponent<NewBall>().previousGoal)
        {
            if (side == Options.Side.Radiant && Ball.GetComponent<NewBall>().lastGoal == false)
            {
                if ((int)PlayerNumber < 0)
                    PlayerNumber = Options.Enum.five;
                Here = Options.ListOfTeams[(int)side].Players[(int)PlayerNumber--];
                GetComponent<SpriteRenderer>().sprite = Here.Face;
            }
            if (side == Options.Side.Dire && Ball.GetComponent<NewBall>().lastGoal == true)
            {
                if ((int)PlayerNumber < 0)
                    PlayerNumber = Options.Enum.five;
                Here = Options.ListOfTeams[(int)side].Players[(int)PlayerNumber--];
                GetComponent<SpriteRenderer>().sprite = Here.Face;
            }
        }
        if (PH == PositionHere.Melle)
        {
            StatsFiling = Here.PFiling / Options.lvlstats1;
            StatsCatch = Here.PCatch + Options.lvlstats2;
        }
        if (PH == PositionHere.Range)
        {
            StatsFiling = Here.PFiling + 15;
            StatsCatch = Here.PCatch;
        }
        if (PH == PositionHere.None)
        {
            StatsFiling = Here.PFiling + Options.lvlstats3;
            StatsCatch = Here.PCatch + Options.lvlstats3;
        }
    }
}
