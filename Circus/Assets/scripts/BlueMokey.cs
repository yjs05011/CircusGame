using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMokey : MonoBehaviour
{
    private Camera main = null;

    private Rigidbody2D rigid;
    private Animator monkeyAni =default;
    private BoxCollider2D box = default;

    private bool isChk =false;
    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.GetComponent<BoxCollider2D>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        monkeyAni = gameObject.GetComponent<Animator>();
        main = Camera.main;
        gameObject.transform.position = new Vector3 (main.transform.position.x+20f,0.35f,0);
    }

    // Update is called once per frame
    void Update()
    {

        if(!isChk){
            rigid.velocity = new Vector2(-7, 0);    
        
        }
       


        
        
        if(gameObject.transform.position.x<main.transform.position.x-12f){
            gameObject.SetActive(false);
        }
        


    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Dead")){
            isChk = true;
            Debug.Log($"blueMonkey {isChk}");
            rigid.AddForce(new Vector2(7,rigid.velocity.y+6));
            StartCoroutine(Waiting());
        }
    }

        public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        isChk = false;
        
    }
}
