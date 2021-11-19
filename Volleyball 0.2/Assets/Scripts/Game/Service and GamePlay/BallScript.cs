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

    public GameObject TargetFuture = null;
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
        ServiceGame.Waiter = true;
    }
    void Update()
    {
        _way?.Invoke();
        ServiceGame.DistanceCalculate(TargetNow, transform.position);
        if (TargetFuture != null)
            ServiceGame.Test(ref TargetNow, ref TargetFuture, this, TargetNow.GetComponent<Position>(), TargetFuture.GetComponent<Position>());
        if (ServiceGame.Waiter == true)
            Wait();
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
        if (ServiceGame.Distance < (ServiceGame.MaxDistance * ServiceGame.MaxDistance)
            && TargetFuture == null && ServiceGame.WhoseMove == true
            && ServiceGame.Waiter == true)
        {
            ServiceGame.Waiter = false;
            Invoke("WaitGoal", 1.5f);
        }
        else
            CancelInvoke("WaitGoal");
        if (TargetFuture == null && ServiceGame.WhoseMove == true)
            SetTrue(Controlers);
        else
            SetFalse(Controlers);
        if (ServiceGame.Distance <= ServiceGame.MaxDistance * ServiceGame.MaxDistance && ServiceGame.WhoseMove == false)
            ServiceGame.TurnDire(ref TargetFiling, ref ChoiceNeighbor);
    }
    public void SetFalse(GameObject Object)
    {
        Object.SetActive(false);
    }
    public void SetTrue(GameObject Object)
    {
        Object.SetActive(true);
    }
    public void WaitGoal()
    {
        ServiceGame.Goal(this);
    }
}

