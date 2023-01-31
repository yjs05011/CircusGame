using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Scene nowScene = default;
    private static GameManager instance = null;
    private static GameObject gameObject;
    public static GameManager Instance{
        get{
            if(instance == null){
                gameObject = new GameObject();
                gameObject.name = "GameManager";
                instance = gameObject.AddComponent(typeof(GameManager)) as GameManager;
            }else{
                Destroy(gameObject);
            }

            return instance;
        }
    }
    void Awake(){
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
