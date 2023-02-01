using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiBoard : MonoBehaviour
{
    public TMP_Text[] score =null;

    public bool flag = false;
    int digit =0;
    // Start is called before the first frame update
    void Start()
    {
        score[0].text = $"{GameManager.instance.player.Score}";
        score[1].text = $"Stage-{GameManager.instance.player.StageNum}";
        score[2].text = $"{GameManager.instance.player.BoundsScore}";
         
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(!flag&& GameManager.instance.player.BoundsScore>=0){
            flag =true;
            StartCoroutine(BonusDiscount());
            GameManager.instance.player.BoundsScore -=10;
            score[0].text = $"{GameManager.instance.player.Score}";
            score[2].text = $"{GameManager.instance.player.BoundsScore}";
        }
        
        
        
        
    }
    private string Score(float score){
        int digit =0;
        while(score/10 !=0){
            score /= 10;
            digit++;
            }
        Debug.Log(digit);
        string[] ZeroCount = new string[]{"00000","0000","000","00","0"};
        string result;
        if(score == 0){
            result = "000000";
        }else{
            result = $"{ZeroCount[digit]}{score}";
        }
        
        return result;
    }
    
    private IEnumerator BonusDiscount(){
        yield return new WaitForSeconds(0.3f);
        flag = false;
    }
    
}
