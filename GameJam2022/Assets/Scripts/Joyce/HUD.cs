using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI candyCount;
    void Start()
    {
        candyCount.text = "x 0";
    }

    void Update()
    {
        candyCount.text = "x " + GameStateManager.candies.ToString();
    }
}
