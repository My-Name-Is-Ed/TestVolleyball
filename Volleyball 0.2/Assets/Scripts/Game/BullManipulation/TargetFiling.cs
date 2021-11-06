using UnityEngine;

public class TargetFiling : MonoBehaviour
{
    public BallScript BallScript { get; set; }
    public void FilingLeft()
    {
        GameObject[] Zone = BallScript.WhoseMove
            ? new GameObject[] { BallScript.PositionD0, BallScript.PositionD1 }
            : new GameObject[] { BallScript.PositionR0, BallScript.PositionR1 };
        Filing(Zone);
        BallScript.PositionD0.GetComponent<Position>().BackLight.SetActive(false);
        BallScript.PositionD1.GetComponent<Position>().BackLight.SetActive(false);
    }
    public void FilingMid()
    {
        GameObject[] Zone = BallScript.WhoseMove
            ? new GameObject[] { BallScript.PositionD2, BallScript.PositionD5 }
            : new GameObject[] { BallScript.PositionR2, BallScript.PositionR5 };
        Filing(Zone);
        BallScript.PositionD2.GetComponent<Position>().BackLight.SetActive(false);
        BallScript.PositionD5.GetComponent<Position>().BackLight.SetActive(false);
    }
    public void FilingRight()
    {
        GameObject[] Zone = BallScript.WhoseMove
            ? new GameObject[] { BallScript.PositionD3, BallScript.PositionD4 }
            : new GameObject[] { BallScript.PositionR3, BallScript.PositionR4 };
        Filing(Zone);
        BallScript.PositionD3.GetComponent<Position>().BackLight.SetActive(false);
        BallScript.PositionD4.GetComponent<Position>().BackLight.SetActive(false);
    }
    private void Filing(GameObject[] Zone)
    {
        BallScript.TargetFuture = Zone[Random.Range(0, 2)];
        BallScript.CheckThrow = 1;
        BallScript.CheckThrowText.text = $"{ BallScript.CheckThrow}";
        BallScript.WhoseMove = !BallScript.WhoseMove;
        BallScript.ThrowOrFilling = true;
    }
}
