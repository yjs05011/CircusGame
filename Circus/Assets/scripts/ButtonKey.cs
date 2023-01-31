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
        if(GameManager.Instance.nowScene.name == "PressAny"){
            Debug.Log(GameManager.Instance.nowScene.name);
            // if()
        }
    }
    public void LeftKey(){
        if(GameManager.Instance.nowScene.name == "PressAny"){
            Debug.Log(GameManager.Instance.nowScene.name);
            // if()
        }
    }
    public void RightKey(){
        if(GameManager.Instance.nowScene.name == "PressAny"){
            Debug.Log(GameManager.Instance.nowScene.name);
            // if()
        }
    }
}
