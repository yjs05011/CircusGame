using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_controller : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //!< 45�� ����

    public AudioClip deathSound = default;
    private float jumpForce = 7;
    private bool isGrounded = false;
    private bool JumpButtonChk = false;
    private bool LeftButtonChk = false;
    private bool RightButtonChk = false;
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    private BoxCollider2D playerCollider =null;
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerAni = gameObject.GetComponent<Animator>();
        playerAudio = gameObject.GetComponent<AudioSource>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.player.Die && !GameManager.instance.player.ClearChk){
            Debug.Log($"x :{gameObject.transform.position.x}");
            Debug.Log($"x :{GameManager.instance.CameraCheck}");
            if (-4 < gameObject.transform.position.x && 100 > gameObject.transform.position.x)
            {
                GameManager.instance.CameraCheck = true;
            }
            else { GameManager.instance.CameraCheck = false; };
            Debug.Log(isGrounded);

            if (GameManager.instance.player.Life < 0)
            {

                return;
            }
            Debug.Log(playerRigid.transform.position.x);
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                if (JumpButtonChk)
                {

                }
                else
                {

                    playerRigid.velocity = new Vector2(-speed, 0);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log($"jumptest {isGrounded}");
                        if (isGrounded)
                        {
                            JumpButtonChk = true;
                            playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                            isGrounded = false;
                        }
                    }
                }

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {

                if (JumpButtonChk)
                {

                }
                else
                {

                    playerRigid.velocity = new Vector2(speed, 0);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log($"jumptest {isGrounded}");
                        if (isGrounded)
                        {
                            JumpButtonChk = true;
                            playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                            isGrounded = false;


                        }
                    }

                }

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log($"jumptest {isGrounded}");
                if (isGrounded)
                {
                    JumpButtonChk = true;
                    playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    isGrounded = false;
                }

            }
            if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) && isGrounded)
            {
                playerRigid.velocity = new Vector2(0, 0);
            }
            // if(!isGrounded){

            // }
            // else
            // {
            //     playerRigid.velocity = new Vector2(0, 0);
            // }
            // playerAni.SetBool("Grounded", isGrounded);
            // Debug.Log(gameObject.transform.position);
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     JumpButtonDown();
            // }
            // Debug.Log(isGrounded);
            // if (GameManager.instance.player.Die)
            // {
            //     return;
            // }
            // Debug.Log(playerRigid.transform.position.x);
            // if (LeftButtonChk)
            // {
            //     playerRigid.velocity = new Vector2(-speed, 0);
            // }
            // else if (RightButtonChk)
            // {
            //     playerRigid.velocity = new Vector2(speed, 0);

            // }else if(!isGrounded){

            // }
            // else
            // {
            //     playerRigid.velocity = new Vector2(0, 0);
            // }
            // playerAni.SetBool("Grounded", isGrounded);


        }

    }

    private void Die(){

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"jumptest trigger");
       
        if (collision.tag.Equals("Ground") && GameManager.instance.player.Die == false)
        {
            isGrounded = true;
            JumpButtonChk= false;
            Debug.Log(isGrounded);
            
        }
        if (collision.tag.Equals("Goal")&& GameManager.instance.player.Die == false){

            GameManager.instance.player.ClearChk =true;

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Dead") && GameManager.instance.player.Die == false)
        {

            GameManager.instance.player.Die = true;
            playerRigid.velocity = new Vector2(0, 0);
            playerRigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            playerCollider.isTrigger = true;

        }
        if (other.tag.Equals("Goal")&& GameManager.instance.player.Die == false){
            playerRigid.velocity = new Vector2(0, 0);
            GameManager.instance.player.ClearChk =true;
            Debug.Log(GameManager.instance.player.ClearChk);
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    public void JumpButtonDown(){
        
        
    }

    public void LeftButtonDown(){
        if(isGrounded){
            LeftButtonChk = true;
        }
       
    }public void LeftButtonUp(){
            LeftButtonChk = false;
       
    }
    public void RightButtonDown(){
        if(isGrounded){
            RightButtonChk = true;
        }
       
    }public void RightButtonUp(){
            RightButtonChk = false;
       
    }
    
}
