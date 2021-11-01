using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillingCollider : MonoBehaviour
{
 public enum Zone
    { 
        Left,
        Mid,
        Right
    }

    public GameObject PositionD0;
    public GameObject PositionD1;
    public GameObject PositionD2;
    public GameObject PositionD3;
    public GameObject PositionD4;
    public GameObject PositionD5;

    public Zone mode;

    public GameObject Ball;

    public void OnMouseEnter()
    {
        if (mode == Zone.Left)
        {
            PositionD0.GetComponent<Position>().BackLight.SetActive(true);
            PositionD1.GetComponent<Position>().BackLight.SetActive(true);
        }
        if (mode == Zone.Mid)
        {
            PositionD2.GetComponent<Position>().BackLight.SetActive(true);
            PositionD5.GetComponent<Position>().BackLight.SetActive(true);
        }
        if (mode == Zone.Right)
        {
            PositionD3.GetComponent<Position>().BackLight.SetActive(true);
            PositionD4.GetComponent<Position>().BackLight.SetActive(true);
        }
            
    }
    public void OnMouseExit()
    {
        if (mode == Zone.Left)
        {
            PositionD0.GetComponent<Position>().BackLight.SetActive(false);
            PositionD1.GetComponent<Position>().BackLight.SetActive(false);
        }
        if (mode == Zone.Mid)
        {
            PositionD2.GetComponent<Position>().BackLight.SetActive(false);
            PositionD5.GetComponent<Position>().BackLight.SetActive(false);
        }
        if (mode == Zone.Right)
        {
            PositionD3.GetComponent<Position>().BackLight.SetActive(false);
            PositionD4.GetComponent<Position>().BackLight.SetActive(false);
        }
    }
}
