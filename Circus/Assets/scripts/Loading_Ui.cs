using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading_Ui : MonoBehaviour
{
    public bool chk =false;
    public int count = 0;
    public TMP_Text stageText;
    // Start is called before the first frame update
    void Start()
    {
        stageText.text = $"Stage {GameManager.instance.player.StageNum}";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!chk){
            chk =true;
            StartCoroutine("Waiting");
            count++;
            Debug.Log(count);
            if(count == 2){
                SceneManager.LoadScene($"Stage{GameManager.instance.player.StageNum%2}");
            }
            
        }
       
    }
    public IEnumerator Waiting(){
        yield return new WaitForSeconds(1f);
        chk = false;
    }
}
