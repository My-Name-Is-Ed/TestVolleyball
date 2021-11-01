using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBall : MonoBehaviour
{
    public GameObject TargetNow;
    GameObject TargetFuture;

    public GameObject NewRound_;

    public GameObject LineRenderer;

    public GameObject Controlers;

    public GameObject Winner;
    public Text winnerText;

    public Text CheckRadiant;
    public Text CheckDire;

    public Text CheckThrow_;

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

    public bool WhoseMove = true; // true = Radiant; false = Dire
    public bool previousGoal = false; // true = Radiant; false = Dire
    public bool lastGoal = false; // true = Radiant; false = Dire
    bool IsCallOnce = false;
    bool ThrowOrFilling;

    float Distance;

    int checkThrow;

    delegate void way();
    way Way;
    way[] DireWay;

    float randValue;

    void Start()
    {
        if (Options.ModeLine == true)
        {
            LineRenderer.SetActive(true);
            Way += LineRender;
        }
        if (Options.ModeOn == Options.Mode.Moving)
            Way += Moving;
        if (Options.ModeOn == Options.Mode.Learping)
            Way += Learping;
        Way += Test;
        Way += Distance_;
        float randValue = Random.value;

    }
    void Update()
    {
        Way?.Invoke();
    }
    public void butterLeft()
    {
        TargetNow.GetComponent<Position>().NeighborLeft.GetComponent<Position>().BackLight.SetActive(false);
        TargetFuture = TargetNow.GetComponent<Position>().NeighborLeft;
        checkThrow++;
        CheckThrow_.text = $"{checkThrow}";
        speed += 0.1f;

        ThrowOrFilling = false;

    }
    public void butterMid()
    {
        TargetNow.GetComponent<Position>().NeighborMid.GetComponent<Position>().BackLight.SetActive(false);
        TargetFuture = TargetNow.GetComponent<Position>().NeighborMid;
        checkThrow++;
        CheckThrow_.text = $"{checkThrow}";
        speed += 0.1f;

        ThrowOrFilling = false;
    }
    public void butterRight()
    {
        TargetNow.GetComponent<Position>().NeighborRight.GetComponent<Position>().BackLight.SetActive(false);
        TargetFuture = TargetNow.GetComponent<Position>().NeighborRight;
        checkThrow++;
        CheckThrow_.text = $"{checkThrow}";
        speed += 0.1f;

        ThrowOrFilling = false;
    }
    public void FilingLeft()
    {
        GameObject[] Zone = WhoseMove ? new GameObject[] { PositionD0, PositionD1 } : new GameObject[] { PositionR0, PositionR1 };
        TargetFuture = Zone[Random.Range(0, 2)];
        checkThrow = 1;
        CheckThrow_.text = $"{checkThrow}";
        WhoseMove = !WhoseMove;

        ThrowOrFilling = true;

        PositionD0.GetComponent<Position>().BackLight.SetActive(false);
        PositionD1.GetComponent<Position>().BackLight.SetActive(false);
    }
    public void FilingMid()
    {
        GameObject[] Zone = WhoseMove ? new GameObject[] { PositionD2, PositionD5 } : new GameObject[] { PositionR2, PositionR5 };
        TargetFuture = Zone[Random.Range(0, 2)];
        checkThrow = 1;
        CheckThrow_.text = $"{checkThrow}";
        WhoseMove = !WhoseMove;

        ThrowOrFilling = true;

        PositionD2.GetComponent<Position>().BackLight.SetActive(false);
        PositionD5.GetComponent<Position>().BackLight.SetActive(false);
    }
    public void FilingRight()
    {
        GameObject[] Zone = WhoseMove ? new GameObject[] { PositionD3, PositionD4 } : new GameObject[] { PositionR3, PositionR4 };
        TargetFuture = Zone[Random.Range(0, 2)];
        checkThrow = 1;
        CheckThrow_.text = $"{checkThrow}";
        WhoseMove = !WhoseMove;

        ThrowOrFilling = true;

        PositionD3.GetComponent<Position>().BackLight.SetActive(false);
        PositionD4.GetComponent<Position>().BackLight.SetActive(false);
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
    public void Test()
    {
        if (checkThrow > 3)
            Goal();
        if ((Distance <= MaxDistance * MaxDistance) && TargetFuture != null)
        {
            if (ThrowOrFilling == true)
                if (Random.Range(0, 101) >= TargetNow.GetComponent<Position>().StatsFiling | Random.Range(0, 101) >= TargetFuture.GetComponent<Position>().StatsCatch)
                {
                    Goal();
                    return;
                }
            if (ThrowOrFilling == false)
                if (Random.Range(0, 101) >= TargetNow.GetComponent<Position>().Here.PThrow | Random.Range(0, 101) >= TargetFuture.GetComponent<Position>().StatsCatch)
                {
                    Goal();
                    return;
                }
            TargetNow = TargetFuture;
            TargetFuture = null;
        }
        if ((Distance < MaxDistance * MaxDistance) && TargetFuture == null && WhoseMove == true)
        {
            IsCallOnce = true;
            Invoke("WaitGoal", 1.5f);
        }
        else
            CancelInvoke("WaitGoal");
        if (TargetFuture == null && WhoseMove == true)
            Controlers.SetActive(true);
        else
            Controlers.SetActive(false);
        if (Distance <= MaxDistance * MaxDistance && WhoseMove == false)
            TurnDire();
    }
    void Goal()
    {
        Way -= Moving;
        Way -= Learping;
        Way -= Test;
        Way -= Distance_;
        Way -= LineRender;

        previousGoal = lastGoal;
        lastGoal = WhoseMove;

        if (WhoseMove == true)
            CheckDire_++;
        else
            CheckRadiant_++;
        

        CheckRadiant.text = $"{CheckRadiant_}";
        CheckDire.text = $"{CheckDire_}";

        PositionD2.SetActive(false);
        PositionD2.GetComponent<Position>().BackLight.SetActive(false);
        PositionR2.SetActive(false);
        PositionR2.GetComponent<Position>().BackLight.SetActive(false);
        NewRound_.SetActive(true);
        Controlers.SetActive(false);

        WhoseMove = !WhoseMove;
    }
    void TurnDire()
    {
        DireWay = new way[] {butterLeft, butterMid, butterRight, FilingLeft, FilingMid, FilingRight};
        if (checkThrow < 3)
            DireWay[Random.Range(0, 6)]();
        else
            DireWay[Random.Range(4, 6)]();
    }
    public void NewRound()
    {
        if (CheckDire_ == 16 | CheckRadiant_ == 16)
        {
            if (CheckDire_ == 16)
                winnerText.text = $"Победитель{Options.ListOfTeams[1].NameTeam}";
            if (CheckRadiant_ == 16)
                winnerText.text = $"Победитель{Options.ListOfTeams[0].NameTeam}";
            Winner.SetActive(true);
        }
        else
        {
            PositionD2.SetActive(true);
            PositionR2.SetActive(true);
            NewRound_.SetActive(false);
            IsCallOnce = false;
            transform.position = WhoseMove ? PositionD0.transform.position : PositionR0.transform.position;

            WhoseMove = !WhoseMove;

            DireWay = new way[] { FilingLeft, FilingMid, FilingRight };
            DireWay[Random.Range(0, 3)]();

            if (Options.ModeOn == Options.Mode.Moving)
                Way += Moving;
            if (Options.ModeOn == Options.Mode.Learping)
                Way += Learping;
            Way += Test;
            Way += Distance_;
            if (Options.ModeLine == true)
            {
                LineRenderer.SetActive(true);
                Way += LineRender;
            }
        }
    }
    void WaitGoal()
    {
        if (IsCallOnce)
        {
            Goal();
            IsCallOnce = false;
        }
    }
    void Distance_()
    {
        Distance = (transform.position - TargetNow.transform.position).sqrMagnitude;
    }
}
