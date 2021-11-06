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

    private bool _nextTo = false;
    private bool _modeBool = false;
    private float _maxDistance = .01f;
    private Vector3 _target;

    private void Update()
    {
        if (Options.ModeOn == Mode.Moving)
        {
            _target = _nextTo ? Player1.transform.position : Player2.transform.position;
            Ball.transform.position = Vector3.MoveTowards(Ball.transform.position, _target, Time.deltaTime * Options.Speed);
        }
        if (Options.ModeOn == Mode.Learping)
        {
            _target = _nextTo ? Player1.transform.position : Player2.transform.position;
            Ball.transform.position = Vector3.Lerp(Ball.transform.position, _target, Time.deltaTime * Options.Speed);
        }
        var Distance = (Ball.transform.position - _target).sqrMagnitude;
        if (Distance < _maxDistance * _maxDistance)
            _nextTo = !_nextTo;

        Options.SizeBall = SliderBall.value * 4 + 3;
        Options.SizePlayers = SliderPlayer.value * 15 + 10;

        Ball.transform.localScale = new Vector3(Options.SizeBall, Options.SizeBall, 0f);
        Player1.transform.localScale = new Vector3(Options.SizePlayers, Options.SizePlayers, 0f);
        Player2.transform.localScale = new Vector3(Options.SizePlayers, Options.SizePlayers, 0f);

        if (Options.ModeLine == true)
        {
            LineRenderer.SetActive(true);
            LineRenderer.GetComponent<LineRenderer>().SetPositions(new Vector3[] { Ball.transform.position, _target });
        } 
        else
            LineRenderer.SetActive(false);
    }
    public void OnClickMode()
    {
        Options.ModeOn = _modeBool ? Mode.Moving : Mode.Learping;
        _modeBool = !_modeBool;
        ButMode.text = $"Режим: {Options.ModeOn}";
    }
    public void OnClickLine()
    {
        Options.ModeLine = Options.ModeLine ? false : true;
        string text = Options.ModeLine ? "Да" : "Нет";
        ButLine.text = $"Траектория: {text}";

    }
}
