using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayData
{
    public float playerX;
    public float playerY;
    public bool fireCondition;
    public bool isGround;
    public float jumpTimeCounter;
    public float rageTime;
    public float time = 0;
    public float calmTime = 0f;
    public float curTime;
    public int count;
    public int points;

   public PlayData(Player player)
    {
        playerX = player.player.transform.position.x;
        playerY = player.player.transform.position.y;
        fireCondition = player.fireCondition;
        isGround = player.isGround;
        jumpTimeCounter = player.jumpTimeCounter;
        rageTime = player.rageTime;
        calmTime = OnFireHint.calmTime;
        curTime = player.curTime;
    }
    public PlayData(OnFireHint ofh)
    {
        calmTime = OnFireHint.calmTime;
        count = ofh.count;
    }

    public PlayData()
    {
        points = ScoreManager.getPoints();
    }
}
