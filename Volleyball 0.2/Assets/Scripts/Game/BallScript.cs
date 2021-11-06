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
    public int CheckRadiantCounter;
    public int CheckDireCounter;
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

    public bool WhoseMove = true;
    public bool previousGoal = false;
    public bool lastGoal = false;

    public GameObject TargetFuture { get; set; }
    public float MaxDistance { get; set; } = .01f;
    public float Speed { get; set; } = 3f;
    public bool ThrowOrFilling { get; set; } = false;
    public float Distance { get; set; }
    public int CheckThrow { get; set; }
    public Position Position => TargetNow.GetComponent<Position>();

    private Action _way;

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

        _way += Test;
        _way += DistanceCalculate;

        ChoiceNeighbor.BallScript = this;
        TargetFiling.BallScript = this;
    }
    void Update()
    {
        _way?.Invoke();
    }

    public void Test()
    {
        if (CheckThrow > 3)
            Goal();
        if ((Distance <= MaxDistance * MaxDistance) && TargetFuture != null)
        {
            if (ThrowOrFilling == true)
                if (Random.Range(0, 101) >= TargetNow.GetComponent<Position>().StatsFiling || 
                    Random.Range(0, 101) >= TargetFuture.GetComponent<Position>().StatsCatch)
                {
                    Goal();
                    return;
                }
            if (ThrowOrFilling == false)
                if (Random.Range(0, 101) >= TargetNow.GetComponent<Position>().Here.PThrow || 
                    Random.Range(0, 101) >= TargetFuture.GetComponent<Position>().StatsCatch)
                {
                    Goal();
                    return;
                }
            TargetNow = TargetFuture;
            TargetFuture = null;
        }
        if ((Distance < MaxDistance * MaxDistance) && TargetFuture == null && WhoseMove == true)
        {
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
    public void NewRound()
    {
        if (CheckDireCounter == 16 | CheckRadiantCounter == 16)
        {
            if (CheckDireCounter == 16)
                winnerText.text = $"Победитель{Options.ListOfTeams[1].NameTeam}";
            if (CheckRadiantCounter == 16)
                winnerText.text = $"Победитель{Options.ListOfTeams[0].NameTeam}";
            Winner.SetActive(true);
        }
        else
        {
            PositionD2.SetActive(true);
            PositionR2.SetActive(true);
            NewRound_.SetActive(false);
            transform.position = WhoseMove ? PositionD0.transform.position : PositionR0.transform.position;

            WhoseMove = !WhoseMove;

            var direWay = new Action[] { TargetFiling.FilingLeft, TargetFiling.FilingMid, TargetFiling.FilingRight };
            direWay[Random.Range(0, 3)]();

            if (Options.ModeOn == Mode.Moving)
                _way += Moving;
            if (Options.ModeOn == Mode.Learping)
                _way += Learping;
            _way += Test;
            _way += DistanceCalculate;
            if (Options.ModeLine == true)
            {
                LineRenderer.SetActive(true);
                _way += LineRender;
            }
        }
    }
    private void Learping()
    {
        transform.position = Vector3.Lerp(transform.position, TargetNow.transform.position, Time.deltaTime * Speed);
    }
    private void Goal()
    {
        _way = null;

        previousGoal = lastGoal;
        lastGoal = WhoseMove;

        if (WhoseMove == true)
            CheckDireCounter++;
        else
            CheckRadiantCounter++;

        CheckRadiant.text = $"{CheckRadiantCounter}";
        CheckDire.text = $"{CheckDireCounter}";

        PositionD2.SetActive(false);
        PositionD2.GetComponent<Position>().BackLight.SetActive(false);
        PositionR2.SetActive(false);
        PositionR2.GetComponent<Position>().BackLight.SetActive(false);
        NewRound_.SetActive(true);
        Controlers.SetActive(false);

        WhoseMove = !WhoseMove;
    }
    private void TurnDire()
    {
        var direWay = new Action[] { ChoiceNeighbor.ButterLeft, ChoiceNeighbor.ButterMid, ChoiceNeighbor.ButterRight,
            TargetFiling.FilingLeft, TargetFiling.FilingMid, TargetFiling.FilingRight };
        if (CheckThrow < 3)
            direWay[Random.Range(0, 6)]();
        else
            direWay[Random.Range(3, 6)]();
    }
    private void LineRender()
    {
        LineRenderer.GetComponent<LineRenderer>()
            .SetPositions(new Vector3[] { transform.position, TargetNow.transform.position });
    }
    private void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetNow.transform.position, Time.deltaTime * Speed);
    }
    private void DistanceCalculate()
    {
        Distance = (transform.position - TargetNow.transform.position).sqrMagnitude;
    }
}
