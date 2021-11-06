using UnityEngine;

public enum PositionHere
{
    None,
    Melle,
    Range
}

public class Position : MonoBehaviour
{
    public Numbers PlayerNumber;
    public Side Side;

    public PositionHere PH;

    public GameObject NeighborLeft;
    public GameObject NeighborMid;
    public GameObject NeighborRight;

    public GameObject BackLight;

    public BallScript Ball;

    public Player Here;

    public int StatsCatch;
    public int StatsFiling;

    public Position PositionNeighborLeft => NeighborLeft.GetComponent<Position>();
    public Position PositionNeighborMid => NeighborMid.GetComponent<Position>();
    public Position PositionNeighborRight => NeighborRight.GetComponent<Position>();

    private void Start()
    {
        Here = Options.ListOfTeams[(int)Side].Players[(int)PlayerNumber--];
        GetComponent<SpriteRenderer>().sprite = Here.Face;
        transform.localScale = new Vector3(Options.SizePlayers/50, Options.SizePlayers/50, 0f);
        BackLight.transform.localScale = new Vector3(Options.SizePlayers/2, Options.SizePlayers/2, 0f);
        SetStats();
    }
    public void NewRound()
    {
        if (Ball.lastGoal != Ball.previousGoal)
        {
            if (Side == Side.Radiant && Ball.lastGoal == false)
            {
                SwapTeams();
            }
            if (Side == Side.Dire && Ball.lastGoal == true)
            {
                SwapTeams();
            }
        }

        SetStats();
    }

    private void SwapTeams()
    {
        if ((int)PlayerNumber < 0)
            PlayerNumber = Numbers.five;
        Here = Options.ListOfTeams[(int)Side].Players[(int)PlayerNumber--];
        GetComponent<SpriteRenderer>().sprite = Here.Face;
    }

    private void SetStats()
    {
        switch (PH)
        {
            case PositionHere.None:
                StatsFiling = Here.PFiling + Options.Lvlstats3;
                StatsCatch = Here.PCatch + Options.Lvlstats3;
                break;
            case PositionHere.Melle:
                StatsFiling = Here.PFiling / Options.Lvlstats1;
                StatsCatch = Here.PCatch + Options.Lvlstats2;
                break;
            case PositionHere.Range:
                StatsFiling = Here.PFiling + 15;
                StatsCatch = Here.PCatch;
                break;
        }
    }
}
