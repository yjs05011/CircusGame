using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class ButtonKey : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JumpKey(){
        if(GameManager.instance.nowScene.name == "PressAny"){
            Debug.Log(GameManager.instance.nowScene.name);
            // if()
        }
    }
    public void LeftKey(){
        if(GameManager.instance.nowScene.name == "PressAny"){
            Debug.Log(GameManager.instance.nowScene.name);
            // if()
        }
    }
    public void RightKey(){
        if(GameManager.instance.nowScene.name == "PressAny"){
            Debug.Log(GameManager.instance.nowScene.name);
            // if()
        }
    }
}
