using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFireHint : MonoBehaviour
{
    public int count = 10;
    public static float calmTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.getPoints() != 0 && ScoreManager.getPoints() >= count && calmTime <= 0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.J))
            {
                //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                count += 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveData.SaveOnFireHint(this);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayData data = SaveData.LoadOnFireHint();
            calmTime = data.calmTime;
            count = data.count;
        }
    }

    public static float getCalm()
    {
        return calmTime;
    }

    public static void resetCalm()
    {
        calmTime = 10f;
    }

    public static void deductCalm(float time)
    {
        calmTime -= time;
    }
}
