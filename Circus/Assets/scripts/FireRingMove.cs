using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingMove : MonoBehaviour
{

    private Rigidbody2D ring = null;

    private Camera main = null;
    // Start is called before the first frame update
    void Start()
    {
        ring = gameObject.GetComponent<Rigidbody2D>();
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ring.velocity = new Vector2(-3,0);
        if(gameObject.transform.position.x<main.transform.position.x-12f){
            gameObject.SetActive(false);
        }
    }
}
