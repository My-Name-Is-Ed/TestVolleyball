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

    public static float MaxDistance = .01f;
    public static float Speed  = 3f;
    public static bool ThrowOrFilling  = false;
    public static float Distance; 
    public static int CheckThrow;

    public static int RandomPercent = Random.Range(0, 101);
    public static int RandomDire1 = Random.Range(0, 6);
    public static int RandomDire2 = Random.Range(3, 6);

    public static void Test(GameObject TargetNow, GameObject TargetFuture)
    {
        if (CheckThrow > 3)
            Goal();
        if ((Distance <= MaxDistance * MaxDistance) && TargetFuture != null)
        {
            if (ThrowOrFilling == true)
                if (RandomPercent >= TargetNow.GetComponent<Position>().StatsFiling ||
                    RandomPercent >= TargetFuture.GetComponent<Position>().StatsCatch)
                {
                    Goal();
                    return;
                }
            if (ThrowOrFilling == false)
                if (RandomPercent >= TargetNow.GetComponent<Position>().Here.PThrow ||
                    RandomPercent >= TargetFuture.GetComponent<Position>().StatsCatch)
                {
                    Goal();
                    return;
                }
            TargetNow = TargetFuture;
            TargetFuture = null;

        }
    }
    public static void NewRound()
    {
        if (CheckDireCounter == 16 | CheckRadiantCounter == 16)
        {
            if (CheckDireCounter == 16)
                BallScript.winnerText.text = $"Победитель{Options.ListOfTeams[1].NameTeam}";
            if (CheckRadiantCounter == 16)
                BallScript.winnerText.text = $"Победитель{Options.ListOfTeams[0].NameTeam}";
            BallScript.Winner.SetActive(true);
        }
        else
        {
            BallScript.PositionD2.SetActive(true);
            BallScript.PositionR2.SetActive(true);
            BallScript.NewRound_.SetActive(false);
            BallScript.transform.position = WhoseMove ? BallScript.PositionD0.transform.position : BallScript.PositionR0.transform.position;

            WhoseMove = !WhoseMove;

            var direWay = new Action[] { TargetFiling.FilingLeft, TargetFiling.FilingMid, TargetFiling.FilingRight };
            direWay[Random.Range(0, 3)]();

            if (Options.ModeOn == Mode.Moving)
                BallScript._way += BallScript.Moving;
            if (Options.ModeOn == Mode.Learping)
                BallScript._way += BallScript.Learping;
            BallScript._way += Test;
            BallScript._way += DistanceCalculate;
            if (Options.ModeLine == true)
            {
                BallScript.LineRenderer.SetActive(true);
                BallScript._way += BallScript.LineRender;
            }
            BallScript._way += BallScript.Wait()
        }
    }
    private static void Goal()
    {
        BallScript._way = null;

        previousGoal = lastGoal;
        lastGoal = WhoseMove;

        if (WhoseMove == true)
            CheckDireCounter++;
        else
            CheckRadiantCounter++;

        BallScript.CheckRadiant.text = $"{CheckRadiantCounter}";
        BallScript.CheckDire.text = $"{CheckDireCounter}";

        BallScript.PositionD2.SetActive(false);
        BallScript.PositionD2.GetComponent<Position>().BackLight.SetActive(false);
        BallScript.PositionR2.SetActive(false);
        BallScript.PositionR2.GetComponent<Position>().BackLight.SetActive(false);
        BallScript.NewRound_.SetActive(true);
        BallScript.Controlers.SetActive(false);

        WhoseMove = !WhoseMove;
    }
    public static void DistanceCalculate(GameObject TargetNow, Vector3 position)
    {
        ServiceGame.Distance = (position - TargetNow.transform.position).sqrMagnitude;
    }
    public static void TurnDire()
    {
        var direWay = new Action[] { ChoiceNeighbor.ButterLeft, ChoiceNeighbor.ButterMid, ChoiceNeighbor.ButterRight,
            TargetFiling.FilingLeft, TargetFiling.FilingMid, TargetFiling.FilingRight };
        if (ServiceGame.CheckThrow < 3)
            direWay[RandomDire1]();
        else
            direWay[RandomDire2]();
    }
}
