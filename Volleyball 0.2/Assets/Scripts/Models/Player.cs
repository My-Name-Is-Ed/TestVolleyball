using UnityEngine;

public class Player
{
    public Sprite Face { get; set; }
    public string Name { get; set; }
    public int PCatch { get; set; }
    public int PThrow { get; set; }
    public int PFiling { get; set; }

    public Player(string name, int PoC, int PoT, int PoF)
    {
        Name = name;
        PCatch = PoC;
        PThrow = PoT;
        PFiling = PoF;
    }
}