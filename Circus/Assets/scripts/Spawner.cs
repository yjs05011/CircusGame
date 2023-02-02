using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Camera main = null;
    public GameObject Rollerable= null;
    private GameObject[] spawnner = null; 
    public int ArrayCount =0;
    private int count =0;
    private int pooingCount = 0;
    public static Spawner instance =null;
    private bool chk = false;
    // Start is called before the first frame update
    void Awake(){
        if(null == instance){
            instance = this; 
        }else{
            Destroy(this.gameObject);
        }
    
    }

    void Start()
    {
        spawnner = new GameObject[ArrayCount];
        for(int i = 0; i< spawnner.Length; i++ ){
            GameObject Objs = Instantiate(Rollerable);
            Objs.transform.SetParent(gameObject.transform);
            Objs.SetActive(false);
            spawnner[i] = Objs;
            
        }

        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.SetPositionAndRotation(new Vector3 (main.transform.position.x +14f,0,0),new Quaternion(0,0,0,0)) ;

         if (!chk)
            {
                
                chk = true;
                StartCoroutine("Waiting");
                if (count == 2)
                {
                    Debug.Log("hi");
                    spawnner[pooingCount].SetActive(true);

                   pooingCount ++;
                   if( pooingCount >ArrayCount){
                    pooingCount =0;
                   }
                   count = 0;



                }
            }
   
    }
    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        chk = false;
        count++;
    }
}
