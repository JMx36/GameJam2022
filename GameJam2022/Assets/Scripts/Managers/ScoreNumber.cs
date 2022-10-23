using UnityEngine;
using TMPro;

public class ScoreNumber : MonoBehaviour
{   
    // Start is called before the first frame update
    void Awake()
    {
        TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
        GameStateManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateManager>();
        text.text = gm.getHighScore().ToString();
    }

}
