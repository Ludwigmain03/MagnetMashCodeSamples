using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI updateText;
    float scoreToDisplay;
    float scoreReal;

    bool update;
    Animator anim;

    public float countSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (update)
        {
            scoreToDisplay += Mathf.Abs(scoreReal - scoreToDisplay) * countSpeed * Time.deltaTime;
            int displayReal = Mathf.RoundToInt(scoreToDisplay);
            scoreText.text = "" + displayReal;
            if (scoreToDisplay == scoreReal)
                update = false;
        }
    }

    public void UpdateScore(float increase)
    {
        scoreReal += increase;
        update = true;
        updateText.text = "+" + increase;
        anim.SetTrigger("Update");
    }

    public void Reset()
    {
        scoreReal = 0;
        scoreToDisplay = 0;
        scoreText.text = "0";
    }
}
