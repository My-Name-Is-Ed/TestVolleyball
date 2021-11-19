using UnityEngine;

public enum Neighbor
{
    Left,
    Mid,
    Right,
}

public class ThrowCollider : MonoBehaviour
{
    public Neighbor mode;
    public BallScript Ball;
    
    public void OnMouseEnter()
    {
        var neighbor = GetNeighbor();
        neighbor.BackLight.SetActive(true);
    }

    public void OnMouseExit()
    {
        var neighbor = GetNeighbor();
        neighbor.BackLight.SetActive(false);
    }

    private Position GetNeighbor()
    {
        var targetNow = Ball.TargetNow.GetComponent<Position>();
        Position neighbor = null;
        switch (mode)
        {
            case Neighbor.Left:
                neighbor = targetNow.NeighborLeft.GetComponent<Position>();
                break;
            case Neighbor.Mid:
                neighbor = targetNow.NeighborMid.GetComponent<Position>();
                break;
            case Neighbor.Right:
                neighbor = targetNow.NeighborRight.GetComponent<Position>();
                break;
        }

        return neighbor;
    }

}
