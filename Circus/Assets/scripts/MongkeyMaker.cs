using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongkeyMaker : MonoBehaviour
{
    [SerializeField]
    public GameObject player =null;
    public GameObject Rollerable= null;
    private GameObject[] spawnner = null; 
    public GameObject position = null;
    public int ArrayCount =0;
    private int count =0;
    private int pooingCount = 0;
    public static MongkeyMaker instance =null;
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
        Debug.Log($"stage {GameManager.instance.stageNum}");
        spawnner = new GameObject[ArrayCount];
        for(int i = 0; i< spawnner.Length; i++ ){
            GameObject Objs = Instantiate(Rollerable);
            Objs.transform.SetParent(position.transform);
            Objs.SetActive(false);
            spawnner[i] = Objs;
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        

         if (!chk)
            {
                
                chk = true;
                StartCoroutine("Waiting");
                if (count == 4)
                {
                    
                    
                    spawnner[pooingCount].SetActive(true);
                    spawnner[pooingCount].transform.position =new Vector3 (player.transform.position.x+14f,0.35f,0);
                    Debug.Log($"ring : {spawnner[pooingCount].transform.position}" );
                     Debug.Log($"main : {player.transform.position}" );
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
