using System;
using UnityEngine;
using Random = UnityEngine.Random;
public static class ServiceGame
{
    public static int CheckRadiantCounter;
    public static int CheckDireCounter;

    public static bool WhoseMove = true;
    public static bool previousGoal = false;
    public static bool lastGoal = false;
    public static bool Waiter = false;

    public static float MaxDistance = .01f;
    public static float Speed  = 5f;
    public static bool ThrowOrFilling  = false;
    public static float Distance; 
    public static int CheckThrow;

    public static int RandomPercent => Random.Range(0, 101);
    public static int RandomDire1 => Random.Range(0, 6);
    public static int RandomDire2 => Random.Range(3, 6);
    public static int RandomDire3 => Random.Range(0, 3);

    public static void Test(ref GameObject TargetNow, ref GameObject TargetFuture, BallScript ballScript, Position positionNow, Position positionFuture)
    {
        if (CheckThrow > 3)
            Goal(ballScript);
        if ((Distance <= MaxDistance * MaxDistance) && TargetFuture != null)
        {
            if (ThrowOrFilling == true)
                if (RandomPercent >= positionNow.StatsFiling ||
                    RandomPercent >= positionFuture.StatsCatch)
                {
                    Goal(ballScript);
                    return;
                }
            if (ThrowOrFilling == false)
                if (RandomPercent >= positionNow.Here.PThrow ||
                    RandomPercent >= positionFuture.StatsCatch)
                {
                    Goal(ballScript);
                    return;
                }
            TargetNow = TargetFuture;
            TargetFuture = null;
        }
    }
    public static void NewRound(ref BallScript ballScript, ref TargetFiling targetFiling)
    {
        if (CheckDireCounter == 16 | CheckRadiantCounter == 16)
        {
            if (CheckDireCounter == 16)
                ballScript.winnerText.text = $"Победитель{Options.ListOfTeams[1].NameTeam}";
            if (CheckRadiantCounter == 16)
                ballScript.winnerText.text = $"Победитель{Options.ListOfTeams[0].NameTeam}";
            ballScript.SetTrue(ballScript.Winner);
        }
        else
        {
            ballScript.SetTrue(ballScript.PositionD2);
            ballScript.SetTrue(ballScript.PositionR2);
            ballScript.SetFalse(ballScript.NewRound_);

            ballScript.transform.position = WhoseMove 
                ? ballScript.PositionD0.transform.position 
                : ballScript.PositionR0.transform.position;

            WhoseMove = !WhoseMove;

            var direWay = new Action[] { targetFiling.FilingLeft, targetFiling.FilingMid, targetFiling.FilingRight };
            direWay[RandomDire3]();

            if (Options.ModeOn == Mode.Moving)
                ballScript._way += ballScript.Moving;
            if (Options.ModeOn == Mode.Learping)
                ballScript._way += ballScript.Learping;
            if (Options.ModeLine == true)
            {
                ballScript.LineRenderer.SetActive(true);
                ballScript._way += ballScript.LineRender;
            }
        }
        Waiter = true;
    }
    public static void Goal(BallScript ballScript)
    {
        ballScript._way = null;

        previousGoal = lastGoal;
        lastGoal = WhoseMove;

        if (WhoseMove == true)
            CheckDireCounter++;
        else
            CheckRadiantCounter++;

        ballScript.CheckRadiant.text = $"{CheckRadiantCounter}";
        ballScript.CheckDire.text = $"{CheckDireCounter}";

        ballScript.PositionD2.SetActive(false);
        ballScript.PositionD2.GetComponent<Position>().BackLight.SetActive(false);
        ballScript.PositionR2.SetActive(false);
        ballScript.PositionR2.GetComponent<Position>().BackLight.SetActive(false);
        ballScript.NewRound_.SetActive(true);
        ballScript.Controlers.SetActive(false);

        WhoseMove = !WhoseMove;
        Waiter = false;
    }
    public static void DistanceCalculate(GameObject TargetNow, Vector3 position)
    {
        ServiceGame.Distance = (position - TargetNow.transform.position).sqrMagnitude;
    }
    public static void TurnDire(ref TargetFiling targetFiling, ref ChoiceNeighbor choiceNeighbor)
    {
        var direWay = new Action[] { choiceNeighbor.ButterLeft, choiceNeighbor.ButterMid, choiceNeighbor.ButterRight,
            targetFiling.FilingLeft, targetFiling.FilingMid, targetFiling.FilingRight };
        if (ServiceGame.CheckThrow < 3)
            direWay[RandomDire1]();
        else
            direWay[RandomDire2]();
    }
}
