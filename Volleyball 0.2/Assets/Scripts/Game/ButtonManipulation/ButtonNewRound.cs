using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNewRound : MonoBehaviour
{
    public BallScript ballscript;
    public void onClick()
    {
        ServiceGame.NewRound(ref ballscript, ref ballscript.TargetFiling);
    }
}
