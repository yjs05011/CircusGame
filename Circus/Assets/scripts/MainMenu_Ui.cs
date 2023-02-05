using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainMenu_Ui : MonoBehaviour
{
    public AudioClip[] sound = null;
    private AudioSource uiSound = null;
    public Toggle[] toggles = null;
    public GameObject Text = null;
    private int blinkTime = 0;
    private bool blinkChk = false;
    private bool changeImg = true;
    private int changeImgTime= 0;
    public GameObject[] TitleImg = null;
    private bool select = false;
    // Start is called before the first frame update
    void Start()
    {
        uiSound = gameObject.GetComponent<AudioSource>();
        GameManager.instance.nowScene = SceneManager.GetActiveScene();
        Debug.Log(GameManager.instance.player);
        GameManager.instance.player.Life = 3;
        GameManager.instance.player.StageNum= 2;
        GameManager.instance.player.BoundsScore = 5000;
        GameManager.instance.player.Score = 0;
        GameManager.instance.player.ClearChk = false;
        GameManager.instance.player.Die = false;
        toggles[0].isOn = true;
        toggles[1].isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!select){
            if(changeImg){
            changeImg = false;
            TitleImg[changeImgTime].SetActive(true);
            
            StartCoroutine("Title");
            changeImgTime++;
            
            
        }


        }
        
        if(blinkChk){
            blinkChk = false;
            StartCoroutine("Blink");
            blinkTime ++;
            if(blinkTime %2 == 0){
                Text.SetActive(true);
            }else{
                Text.SetActive(false);
            }
            if(blinkTime > 10){
                blinkTime =0;
                
                
                Debug.Log(GameManager.instance.player.Life);
                SceneManager.LoadScene("LoadingScene");
            }
        }

        
    }

    public void OnClickJump(){
        if(select){}
        else{
            uiSound.clip = sound[1];
            uiSound.Play();
            select = true; 
            if(toggles[0].isOn == true){
            blinkChk = true;
        }else if(toggles[1].isOn == true){
            Application.Quit();
            Debug.Log("게임 종료");
        }}
       
    }
    public void OnClickArrow(){
        if(select){}
        else{
            uiSound.clip = sound[0];
            uiSound.Play();
        if(toggles[0].isOn == true){
            
            toggles[0].isOn = false;
            toggles[1].isOn = true;
        }else if(toggles[1].isOn == true){
            toggles[0].isOn = true;
            toggles[1].isOn = false;
        }
        }
      
    }
    IEnumerator Blink(){
        
        yield return new WaitForSeconds(0.2f);
        
        blinkChk = true;
    }
    IEnumerator Title(){
        
        yield return new WaitForSeconds(0.1f);
        if(changeImgTime == 3 ){
                for(int i =0 ; i<TitleImg.Length; i++){
                
                    TitleImg[i].SetActive(false);
            }
            changeImgTime =0;
        }
        changeImg = true;
        
    }
    
}