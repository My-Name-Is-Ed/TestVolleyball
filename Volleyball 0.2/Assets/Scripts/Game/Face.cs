using UnityEngine;
using UnityEngine.UI;

public class Face : MonoBehaviour
{
    public Text textCatch;
    public Text textThrow;
    public Text textFiling;
    public Numbers PlayerNumber;
    public Side Side;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Options.ListOfTeams[(int)Side].Players[(int)PlayerNumber].Face;
        textCatch.text = $"{Options.ListOfTeams[(int)Side].Players[(int)PlayerNumber].PCatch} %";
        textThrow.text = $"{Options.ListOfTeams[(int)Side].Players[(int)PlayerNumber].PThrow} %";
        textFiling.text = $"{Options.ListOfTeams[(int)Side].Players[(int)PlayerNumber].PFiling} %";
    }
}
