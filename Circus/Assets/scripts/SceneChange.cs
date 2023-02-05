using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    private bool chk = false;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player.Die)
        {


            if (!chk)
            {
                chk = true;
                StartCoroutine("Waiting");
                count++;
                Debug.Log(count);
                if (count == 4)
                {
                    GameManager.instance.player.Life --;
                    
                    
                    if(GameManager.instance.player.Life==0){
                        SceneManager.LoadScene($"GameOver");
                    }else{
                        SceneManager.LoadScene($"LoadingScene");
                    }
                    GameManager.instance.player.Die = false;
                


                }
            }


        }
        if(GameManager.instance.player.ClearChk){
            
            if (!chk)
            {
                chk = true;
                StartCoroutine("Waiting");
                count++;
                Debug.Log(count);
                if (count == 4)
                {

                    GameManager.instance.player.ClearChk = false;

                        SceneManager.LoadScene($"LoadingScene");
                    



                }
            }
        }
        
    }
    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        chk = false;
    }
}
