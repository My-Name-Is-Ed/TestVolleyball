using UnityEngine;

public class Logo : MonoBehaviour
{
    public Side Side;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Options.ListOfTeams[(int)Side].Logo;
        if (Options.ListOfTeams[(int)Side] == Players.Anime)
            transform.localScale = new Vector3(0.35f, 0.35f, 0f);
    }
}
