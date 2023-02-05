using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoMain : MonoBehaviour
{
    private bool chk =false;
    private int count =0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        if (!chk)
        {
            chk = true;
            StartCoroutine("Waiting");
            count++;
            Debug.Log(count);
            if (count == 2)
            {

                SceneManager.LoadScene($"Init");





            }
        }



    }
    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        chk = false;
    }
}
