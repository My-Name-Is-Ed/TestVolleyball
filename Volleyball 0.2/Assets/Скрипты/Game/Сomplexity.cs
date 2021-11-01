using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Сomplexity : MonoBehaviour
{
    public Text K;

    private void Start()
    {
        K.text = $"Сложность {Options.lvlstats4}";
    }
}
