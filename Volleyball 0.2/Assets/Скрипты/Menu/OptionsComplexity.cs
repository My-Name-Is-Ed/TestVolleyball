using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsComplexity : MonoBehaviour
{
    public void lvl1()
    {
        Options.lvlstats1 = 2;
        Options.lvlstats2 = 30;
        Options.lvlstats3 = 0;
        Options.lvlstats4 = 1;
    }
    public void lvl2()
    {
        Options.lvlstats1 = 2;
        Options.lvlstats2 = 25;
        Options.lvlstats3 = 20;
        Options.lvlstats4 = 2;
    }
    public void lvl3()
    {
        Options.lvlstats1 = 3;
        Options.lvlstats2 = 20;
        Options.lvlstats3 = 30;
        Options.lvlstats4 = 3;
    }
}
