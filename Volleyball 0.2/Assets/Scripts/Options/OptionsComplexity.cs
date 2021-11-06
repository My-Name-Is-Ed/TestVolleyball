using UnityEngine;

public class OptionsComplexity : MonoBehaviour
{
    public void Lvl1()
    {
        Options.Lvlstats1 = 2;
        Options.Lvlstats2 = 30;
        Options.Lvlstats3 = 0;
        Options.Lvlstats4 = 1;
    }
    public void Lvl2()
    {
        Options.Lvlstats1 = 2;
        Options.Lvlstats2 = 25;
        Options.Lvlstats3 = 20;
        Options.Lvlstats4 = 2;
    }
    public void Lvl3()
    {
        Options.Lvlstats1 = 3;
        Options.Lvlstats2 = 20;
        Options.Lvlstats3 = 30;
        Options.Lvlstats4 = 3;
    }
}
