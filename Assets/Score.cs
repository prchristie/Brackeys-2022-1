using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Singleton { get; private set; }
    public TMP_Text text;

    private int score = 0;
    private void Awake()
    {
        if(Singleton != null) Destroy(gameObject);
        Singleton = this;
    }

    public void IncreaseScore()
    {
        score++;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
}
