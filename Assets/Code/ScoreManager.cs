using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    private static int points;
    private static Text perfectionText;
    // Start is called before the first frame update
    void Start()
    {
        perfectionText = GameObject.Find("PerfectionT").GetComponent<Text>();
        points = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveData.SaveScoreManager();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayData data = SaveData.LoadScoreManager();
            points = data.points;
        }
    }

    public static int getPoints()
    {
        return points;
    }

    public static void addPoints(int point)
    {
        points += point;
    }

    public static void UpdateText()
    {
        perfectionText.text = String.Format("City Perfection: {0}", points);
        
    }

}
