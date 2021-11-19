using UnityEngine;
using UnityEngine.UI;

public class Сomplexity : MonoBehaviour
{
    public Text K;

    private void Start()
    {
        K.text = $"Сложность {Options.Lvlstats4}";
    }
}
