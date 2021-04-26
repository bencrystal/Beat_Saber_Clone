using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIScript : Singleton<UIScript>
{
    //public static int score = 0;
    //public static int combo = 0;
    
    public int score = 0;
    public int combo = 0;
    //this represents the quality of the last note hit
    //0 is empty, 1 is perfect, 2 is good, 3 is miss
    //public static int lastNoteHit = 0;
    public int lastNoteHit = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI hitText; //whether the last hit was perfect, good, or a miss

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        comboText.text = "Combo: " + combo.ToString();
        switch (lastNoteHit)
        {
            case 1: //perfect
                hitText.text = "Perfect!";
                break;
            case 2: //good
                hitText.text = "Good!";
                break;
            case 3: //hit
                hitText.text = "Hit!";
                break;
            case 4: //miss
                hitText.text = "Miss!";
                break;
            default: //null
                hitText.text = "";
                break;
        }
    }
}
