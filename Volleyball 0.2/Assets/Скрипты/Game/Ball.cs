using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject TargetNow;
    GameObject TargetFuture;

    public GameObject LineRenderer;

    public GameObject Controlers;

    public Text CheckRadiant;
    public Text CheckDire;

    public int CheckRadiant_;
    public int CheckDire_;

    public GameObject PositionR0;
    public GameObject PositionR1;
    public GameObject PositionR2;
    public GameObject PositionR3;
    public GameObject PositionR4;
    public GameObject PositionR5;

    public GameObject PositionD0;
    public GameObject PositionD1;
    public GameObject PositionD2;
    public GameObject PositionD3;
    public GameObject PositionD4;
    public GameObject PositionD5;

    float MaxDistance = .01f;

    float speed = 3f;

    bool WhoseMove = true; // true = Radiant; false = Dire

    float Distance;

    int checkThrow;

    delegate void way();
    way Way;
    way[] DireWay;

    private void Start()
    {
        if (Options.ModeOn == Options.Mode.Moving)
            Way += Moving;
        if (Options.ModeOn == Options.Mode.Learping)
            Way += Learping;
        transform.localScale = new Vector3(Options.SizeBall/50, Options.SizeBall/50, 0f);

        if (Options.ModeLine == true)
        {
            LineRenderer.SetActive(true);
            Way += LineRender;
        }
    }
    private void Update()
    {
        Way();
        Distance = (transform.position - TargetNow.transform.position).sqrMagnitude;
        if (WhoseMove == true)
            TestToRadiant();
        else
            TestToDire();
    }
    public void butterLeft()
    {
        TargetNow.GetComponent<Position>().NeighborLeft.GetComponent<Position>().BackLight.SetActive(false);
        TargetFuture = TargetNow.GetComponent<Position>().NeighborLeft;
        checkThrow++;
        speed += 0.1f;
    }
    public void butterMid()
    {
        TargetNow.GetComponent<Position>().NeighborMid.GetComponent<Position>().BackLight.SetActive(false);
        TargetFuture = TargetNow.GetComponent<Position>().NeighborMid;
        checkThrow++;
        speed += 0.1f;
    }
    public void butterRight()
    {
        TargetNow.GetComponent<Position>().NeighborRight.GetComponent<Position>().BackLight.SetActive(false);
        TargetFuture = TargetNow.GetComponent<Position>().NeighborRight;
        checkThrow++;
        speed += 0.1f;
    }
    public void FilingLeft()
    {
        GameObject[] Zone = WhoseMove? new GameObject[] {PositionD0, PositionD1} : new GameObject[] { PositionR0, PositionR1 };
        TargetFuture = Zone[Random.Range(0, 2)];
        WhoseMove = !WhoseMove;
    }
    public void FilingMid()
    {
        GameObject[] Zone = WhoseMove ? new GameObject[] { PositionD2, PositionD5 } : new GameObject[] { PositionR2, PositionR5 };
        TargetFuture = Zone[Random.Range(0, 2)];
        WhoseMove = !WhoseMove;
    }
    public void FilingRight()
    {
        GameObject[] Zone = WhoseMove ? new GameObject[] { PositionD3, PositionD4 } : new GameObject[] { PositionR3, PositionR4 };
        TargetFuture = Zone[Random.Range(0, 2)];
        WhoseMove = !WhoseMove;
    }
    void LineRender()
    {
        LineRenderer.GetComponent<LineRenderer>().SetPositions(new Vector3[] { transform.position, TargetNow.transform.position });
    }
    void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetNow.transform.position, Time.deltaTime * speed);
    }
    void Learping()
    {
        transform.position = Vector3.Lerp(transform.position, TargetNow.transform.position, Time.deltaTime * speed);
    }
    void TestToRadiant()
    {
        if (TargetFuture != null)
            Controlers.SetActive(false);
        else
            Controlers.SetActive(true);
        if ((Distance < MaxDistance * MaxDistance)&&TargetFuture == null)
            Goal();
        if ((Distance <= MaxDistance * MaxDistance) && TargetFuture != null)
        {
            TargetNow = TargetFuture;
            TargetFuture = null;
        }
    }
    void TestToDire()
    {
        if (Distance < MaxDistance * MaxDistance)
            TurnDire();
    }
    void Goal()
    {
        if (WhoseMove == true)
        {
            CheckRadiant_ += 1;
            CheckRadiant.text = $"{CheckRadiant_}";
        }
        else
        {
            CheckDire_ += 1;
            CheckDire.text = $"{CheckDire_}";
        }
        Way -= Moving;
        Way -= Learping;
    }
    public void NewRound()
    { 
        
    }
    public void TurnDire()
    {
        DireWay = new way[] { butterLeft, butterMid, butterRight, FilingLeft, FilingMid, FilingRight};
        if (checkThrow < 3)
            DireWay[Random.Range(0, 7)]();
        else
            DireWay[Random.Range(4, 7)]();
    }
}
