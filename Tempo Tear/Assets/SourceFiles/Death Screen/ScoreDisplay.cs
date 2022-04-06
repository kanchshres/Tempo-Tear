using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreDisplay : MonoBehaviour
{
    // Text Object
    private TextMeshProUGUI textMeshH;
    private int score = ScoreSetter.score;

    // Start is called before the first frame update
    void Start()
    {
        textMeshH = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshH.SetText("Final score - " + score.ToString());
    }
}
