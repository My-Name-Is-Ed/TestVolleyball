using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Face : MonoBehaviour
{
    public Text textCatch;
    public Text textThrow;
    public Text textFiling;
    public Options.Enum PlayerNumber;
    public Options.Side side;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Options.ListOfTeams[(int)side].Players[(int)PlayerNumber].Face;
        textCatch.text = $"{Options.ListOfTeams[(int)side].Players[(int)PlayerNumber].PCatch} %";
        textThrow.text = $"{Options.ListOfTeams[(int)side].Players[(int)PlayerNumber].PThrow} %";
        textFiling.text = $"{Options.ListOfTeams[(int)side].Players[(int)PlayerNumber].PFiling} %";
    }
}
