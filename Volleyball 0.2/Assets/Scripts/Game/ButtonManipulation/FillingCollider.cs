using UnityEngine;

public enum Zone
{
    Left,
    Mid,
    Right
}

public class FillingCollider : MonoBehaviour
{
    public Position PositionD0;
    public Position PositionD1;
    public Position PositionD2;
    public Position PositionD3;
    public Position PositionD4;
    public Position PositionD5;
    public Zone Mode;

    public void OnMouseEnter()
    {
        var positions = GetPosition();
        positions.Item1.SetActive(true);
        positions.Item2.SetActive(true);
    }

    public void OnMouseExit()
    {
        var positions = GetPosition();
        positions.Item1.SetActive(false);
        positions.Item2.SetActive(false);
    }

    private (GameObject, GameObject) GetPosition()
    {
        GameObject first = null;
        GameObject second = null;

        switch (Mode)
        {
            case Zone.Left:
                first = PositionD0.BackLight;
                second = PositionD1.BackLight;
                break;
            case Zone.Mid:
                first = PositionD2.BackLight;
                second = PositionD5.BackLight;
                break;
            case Zone.Right:
                first = PositionD3.BackLight;
                second = PositionD4.BackLight;
                break;
        }

        return (first, second);
    }
}
