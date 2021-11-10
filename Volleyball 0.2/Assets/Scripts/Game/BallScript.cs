using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{
    public GameObject TargetNow;
    public GameObject NewRound_;
    public GameObject LineRenderer;
    public GameObject Controlers;
    public GameObject Winner;
    public Text winnerText;
    public Text CheckRadiant;
    public Text CheckDire;
    public Text CheckThrowText;
    public ChoiceNeighbor ChoiceNeighbor;
    public TargetFiling TargetFiling;

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


    public GameObject TargetFuture;
    public Position Position => TargetNow.GetComponent<Position>();

    public Action _way;

    void Start()
    {
        if (Options.ModeLine == true)
        {
            LineRenderer.SetActive(true);
            _way += LineRender;
        }
        if (Options.ModeOn == Mode.Moving)
            _way += Moving;
        else
            _way += Learping;

        ChoiceNeighbor.BallScript = this;
        TargetFiling.BallScript = this;
    }
    void Update()
    {
        _way?.Invoke();
        ServiceGame.Test(TargetNow, TargetFuture);
        ServiceGame.DistanceCalculate(TargetNow, transform.position);
    }
    public void Learping()
    {
        transform.position = Vector3.Lerp(transform.position, TargetNow.transform.position, Time.deltaTime * ServiceGame.Speed);
    }
    public void LineRender()
    {
        LineRenderer.GetComponent<LineRenderer>()
            .SetPositions(new Vector3[] { transform.position, TargetNow.transform.position });
    }
    public void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetNow.transform.position, Time.deltaTime * ServiceGame.Speed);
    }
    public void Wait()
    {
        if ((ServiceGame.Distance < ServiceGame.MaxDistance * ServiceGame.MaxDistance) && TargetFuture == null && ServiceGame.WhoseMove == true)
        {
            Invoke("WaitGoal", 1.5f);
        }
        else
            CancelInvoke("WaitGoal");
        if (TargetFuture == null && ServiceGame.WhoseMove == true)
            Controlers.SetActive(true);
        else
            Controlers.SetActive(false);
        if (ServiceGame.Distance <= ServiceGame.MaxDistance * ServiceGame.MaxDistance && ServiceGame.WhoseMove == false)
            ServiceGame.TurnDire();
    }
}

