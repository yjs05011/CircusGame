using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Position : MonoBehaviour
{
    [SerializeField]
    public GameObject player =null;

    Vector3 cameraPosition = new Vector3(0,0,-10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.CameraCheck){transform.position = new Vector3 (player.transform.position.x,0,0)+new Vector3(4.0684f,0,0) +cameraPosition;}
        
    }
}
