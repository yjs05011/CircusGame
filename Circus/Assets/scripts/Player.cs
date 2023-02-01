using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Start is called before the first frame update
    private int life;
    private float score;
    private float bounsScore;
    private int stageNum;
    private bool clearChk;
    private bool die;

    public int Life
    {
        get; set;
    }
    public int Score
    {
        get; set;

    }
    public int BoundsScore
    {
        get; set;
    }

    public int StageNum
    {
        get; set;

    }
    public bool ClearChk
    {
        get; set;

    }
    public bool Die{
        get; set;
    }

    public Player(){

    }
    public Player(int life, float score, float bounusScore, int stageNum, bool clearChk){
        this.life = life;
        this.score = score;
        this.bounsScore = bounusScore;
        this.stageNum = stageNum;
    }
    public Player FirstPlayer(){
        Player player = new Player(3,0,5000,1,false);
        return player;
    }
}