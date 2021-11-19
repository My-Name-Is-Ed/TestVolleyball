using UnityEngine;

public class ChoiceNeighbor : MonoBehaviour
{
    public BallScript BallScript { get; set; }
    public void ButterLeft()
    {
        BallScript.TargetNow.GetComponent<Position>().PositionNeighborLeft.BackLight.SetActive(false);
        BallScript.TargetFuture = BallScript.Position.NeighborLeft;
        SetTargetFuture();

    }
    public void ButterMid()
    {
        BallScript.TargetNow.GetComponent<Position>().PositionNeighborMid.BackLight.SetActive(false);
        BallScript.TargetFuture = BallScript.Position.NeighborMid;
        SetTargetFuture();
    }
    public void ButterRight()
    {
        BallScript.TargetNow.GetComponent<Position>().PositionNeighborRight.BackLight.SetActive(false);
        BallScript.TargetFuture = BallScript.Position.NeighborRight;
        SetTargetFuture();
    }
    private void SetTargetFuture()
    {
        ServiceGame.CheckThrow++;
        BallScript.CheckThrowText.text = $"{ServiceGame.CheckThrow}";
        ServiceGame.Speed += 0.1f;
        ServiceGame.ThrowOrFilling = false;
        CancelInvoke("WaitGoal");
        ServiceGame.Waiter = true;
    }
}
