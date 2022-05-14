using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    private static Text resultT;
    // Start is called before the first frame update
    void Start()
    {
        resultT = GameObject.Find("ResultMessage").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.getPoints() >= 15)
        {
            resultT.text = String.Format("Congratulations! You're promoted.");
        }
        else
        {
            resultT.text = String.Format("Sorry. Good luck next time.");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
