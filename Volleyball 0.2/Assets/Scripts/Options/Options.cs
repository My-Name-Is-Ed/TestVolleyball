public enum Mode
{
    Moving,
    Learping
}

public enum Numbers
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

public static class Options
{
    static public Team[] ListOfTeams { get; set; } = new Team[] { Players.Boys, Players.Boys };
    static public Mode ModeOn { get; set; } = Mode.Moving;
    static public bool ModeLine { get; set; } = false;
    static public float SizePlayers { get; set; } = 20;
    static public float SizeBall { get; set; } = 5;
    static public float Speed { get; set; } = 5f;
    static public int Lvlstats1 { get; set; } = 2;
    static public int Lvlstats2 { get; set; } = 30;
    static public int Lvlstats3 { get; set; } = 0;
    static public int Lvlstats4 { get; set; } = 1;
}
