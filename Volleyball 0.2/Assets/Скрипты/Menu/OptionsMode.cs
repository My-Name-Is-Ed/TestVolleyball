using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMode : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Player1;
    public GameObject Player2;

    public Slider SliderBall;
    public Slider SliderPlayer;

    public GameObject LineRenderer;

    public Text ButMode;
    public Text ButLine;
    bool NextTo = false;
    bool ModeBool = false;
    float MaxDistance = .01f;
    Vector3 Target;

    private void Update()
    {
        if (Options.ModeOn == Options.Mode.Moving)
        {
            Target = NextTo ? Player1.transform.position : Player2.transform.position;
            Ball.transform.position = Vector3.MoveTowards(Ball.transform.position, Target, Time.deltaTime * Options.speed);
        }
        if (Options.ModeOn == Options.Mode.Learping)
        {
            Target = NextTo ? Player1.transform.position : Player2.transform.position;
            Ball.transform.position = Vector3.Lerp(Ball.transform.position, Target, Time.deltaTime * Options.speed);
        }
        var Distance = (Ball.transform.position - Target).sqrMagnitude;
        if (Distance < MaxDistance * MaxDistance)
            NextTo = !NextTo;

        Options.SizeBall = SliderBall.value * 4 + 3;
        Options.SizePlayers = SliderPlayer.value * 15 + 10;

        Ball.transform.localScale = new Vector3(Options.SizeBall, Options.SizeBall, 0f);
        Player1.transform.localScale = new Vector3(Options.SizePlayers, Options.SizePlayers, 0f);
        Player2.transform.localScale = new Vector3(Options.SizePlayers, Options.SizePlayers, 0f);

        if (Options.ModeLine == true)
        {
            LineRenderer.SetActive(true);
            LineRenderer.GetComponent<LineRenderer>().SetPositions(new Vector3[] { Ball.transform.position, Target });
        } 
        else
            LineRenderer.SetActive(false);
    }
    public void OnClickMode()
    {
        Options.ModeOn = ModeBool ? Options.Mode.Moving : Options.Mode.Learping;
        ModeBool = !ModeBool;
        ButMode.text = $"Режим: {Options.ModeOn}";
    }
    public void OnClickLine()
    {
        Options.ModeLine = Options.ModeLine ? false : true;
        string text = Options.ModeLine ? "Да" : "Нет";
        ButLine.text = $"Траектория: {text}";

    }

}
