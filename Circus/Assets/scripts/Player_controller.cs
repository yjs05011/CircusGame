using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //!< 45�� ����

    public AudioClip deathSound = default;
    public float jumpForce = default;

    private bool isGrounded = false;
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerAni = gameObject.GetComponent<Animator>();
        playerAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.instance.player.Die){
            return;
        }
    }

    private void Die(){
        playerAni.SetTrigger("Die");
        GameManager.instance.player.Die =true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DeadObj") && GameManager.instance.player.Die == false)
        {
            Die();
        }
        if (collision.tag.Equals("Ground") && GameManager.instance.player.Die == false)
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    public void JumpButton(){
        Debug.Log(isGrounded);
        Debug.Log(GameManager.instance.player.Die);
        if(isGrounded){
            isGrounded = false;
            playerRigid.AddForce(new Vector2(0,jumpForce));
        // playerAni.SetBool("Grounded", isGrounded);
            Debug.Log("1");
        }
        
    }
    public void LeftButton(){
        Debug.Log(playerRigid.transform.position.x );
        if(playerRigid.transform.position.x >= -400 ){
            playerRigid.MovePosition(playerRigid.position + new Vector2(0,0) * Time.deltaTime * speed);
        }
    }
    public void RightButton(){

    }

    
}
