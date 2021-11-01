using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollider : MonoBehaviour
{
    public enum Neighbor
    { 
        Left,
        Mid,
        Right
    }
    public Neighbor mode;

    public GameObject Ball;

    

    public void OnMouseEnter()
    {
        if (mode == Neighbor.Left)
            Ball.GetComponent<NewBall>().TargetNow.GetComponent<Position>().NeighborLeft.GetComponent<Position>().BackLight.SetActive(true);
        if (mode == Neighbor.Mid)
            Ball.GetComponent<NewBall>().TargetNow.GetComponent<Position>().NeighborMid.GetComponent<Position>().BackLight.SetActive(true);
        if (mode == Neighbor.Right)
            Ball.GetComponent<NewBall>().TargetNow.GetComponent<Position>().NeighborRight.GetComponent<Position>().BackLight.SetActive(true);
    }
    public void OnMouseExit()
    {
        if (mode == Neighbor.Left)
            Ball.GetComponent<NewBall>().TargetNow.GetComponent<Position>().NeighborLeft.GetComponent<Position>().BackLight.SetActive(false);
        if (mode == Neighbor.Mid)
            Ball.GetComponent<NewBall>().TargetNow.GetComponent<Position>().NeighborMid.GetComponent<Position>().BackLight.SetActive(false);
        if (mode == Neighbor.Right)
            Ball.GetComponent<NewBall>().TargetNow.GetComponent<Position>().NeighborRight.GetComponent<Position>().BackLight.SetActive(false);
    }
}
