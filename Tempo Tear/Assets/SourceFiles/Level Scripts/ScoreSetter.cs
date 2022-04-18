using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    // Variables
    public static int score = 0;
    public static int multiplier = 1;
    private TextMeshProUGUI textMeshH;


    // Start is called before the first frame update
    void Start()
    {
        textMeshH = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
       textMeshH.SetText("Score " + score.ToString() + "\nX" + multiplier.ToString());
    }
}
