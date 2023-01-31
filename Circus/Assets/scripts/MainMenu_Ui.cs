using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu_Ui : MonoBehaviour
{
    public Toggle[] toggles = null;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.nowScene = SceneManager.GetActiveScene();

        toggles[0].isOn = true;
        toggles[1].isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickJump(){
        if(toggles[0].isOn == true){
            SceneManager.LoadScene("Stage 1");
        }else if(toggles[1].isOn == true){
            Application.Quit();
            Debug.Log("게임 종료");
        }
    }
    public void OnClickArrow(){
        if(toggles[0].isOn == true){
            toggles[0].isOn = false;
            toggles[1].isOn = true;
        }else if(toggles[1].isOn == true){
            toggles[0].isOn = true;
            toggles[1].isOn = false;
        }
    }
    
}
