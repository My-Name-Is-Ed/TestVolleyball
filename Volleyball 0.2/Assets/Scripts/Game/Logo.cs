using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public Options.Side side;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Options.ListOfTeams[(int)side].Logo;
        if (Options.ListOfTeams[(int)side] == Players.Anime)
            transform.localScale = new Vector3(0.35f, 0.35f, 0f);
    }

}
