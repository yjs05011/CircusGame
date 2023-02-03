using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_controller : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //!< 45�� ����

    public AudioClip[] Sound = default;
    private float jumpForce = 7;
    private bool isGrounded = false;
    private bool JumpButtonChk = false;
    private bool LeftButtonChk = false;
    private bool RightButtonChk = false;
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    private BoxCollider2D playerCollider =null;
    public GameObject goal = null;
    private float speed = 5    ;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        playerAni = gameObject.transform.GetChild(0).GetComponent<Animator>();
        playerAudio = gameObject.GetComponent<AudioSource>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerCollider.isTrigger = false;
        GameManager.instance.player.BoundsScore = 5000;
        score = GameManager.instance.player.Score;
    }

    // Update is called once per frame
    void Update()
    {

        if(!GameManager.instance.player.Die && !GameManager.instance.player.ClearChk){
            // Debug.Log($"x :{gameObject.transform.position.x}");
            // Debug.Log($"x :{GameManager.instance.CameraCheck}");
            if (-4 < gameObject.transform.position.x && 100 > gameObject.transform.position.x)
            {
                GameManager.instance.CameraCheck = true;
            }
            else { GameManager.instance.CameraCheck = false; };
            // Debug.Log(isGrounded);

            if (GameManager.instance.player.Life < 0)
            {

                return;
            }
            // Debug.Log(playerRigid.transform.position.x);
            if (LeftButtonChk || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                if (JumpButtonChk)
                {

                }
                else
                {
                    playerAni.SetBool("isRun", true);
                    playerRigid.velocity = new Vector2(-speed, 0);
                    // if (Input.GetKeyDown(KeyCode.Space))
                    // {
                    //     // Debug.Log($"jumptest {isGrounded}");
                    //     if (isGrounded)
                    //     {
                    //         JumpButtonChk = true;
                    //         playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    //         isGrounded = false;
                    //     }
                    // }
                }

            }
            if (RightButtonChk||Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (JumpButtonChk)
                {

                }
                else
                {
                    playerAni.SetBool("isRun", true);
                    playerRigid.velocity = new Vector2(speed, 0);
                    // if (Input.GetKeyDown(KeyCode.Space))
                    // {
                    //     Debug.Log($"jumptest {isGrounded}");
                    //     if (isGrounded)
                    //     {
                    //         JumpButtonChk = true;
                    //         playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    //         isGrounded = false;


                    //     }
                    // }

                }

            }
            if (!LeftButtonChk && !RightButtonChk && isGrounded)
            {
                playerRigid.velocity = new Vector2(0, 0);
                playerAni.SetBool("isRun", false);
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
        // Debug.Log($"jumptest trigger");
       
        if (collision.tag.Equals("Ground") && GameManager.instance.player.Die == false)
        {
            isGrounded = true;
            JumpButtonChk= false;
            // Debug.Log(isGrounded);
            playerAni.SetBool("isJump", false);
            
            
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Dead") && GameManager.instance.player.Die == false)
        {

            GameManager.instance.player.Die = true;
            GameManager.instance.player.Score = score;
            playerAudio.clip = Sound[0];
            playerAudio.Play();
            playerRigid.velocity = new Vector2(0, 0);
            playerRigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            playerCollider.isTrigger = true;
            playerAni.SetBool("isDie", true);

        }if (other.tag.Equals("Goal")&& GameManager.instance.player.Die == false && GameManager.instance.player.ClearChk == false){
            playerRigid.velocity = new Vector2(0, 0);
            playerAudio.clip = Sound[1];
            playerAudio.Play();
            Debug.Log(gameObject.transform.position.x);
            playerAni.SetBool("isClear", true);
            GameManager.instance.player.ClearChk =true;
            GameManager.instance.player.StageNum += 1;
            GameManager.instance.player.Score += GameManager.instance.player.BoundsScore;
            // Debug.Log($"chil : {gameObject.transform.position}");
            
            playerRigid.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
            playerRigid.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
            
            Debug.Log("Add Ultimate score");

        }

            
        if (other.tag.Equals("Score")&& GameManager.instance.player.Die == false){
            GameManager.instance.player.Score += 100;
            
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        playerAni.SetBool("isJump", true);
    }
    public void JumpButtonDown()
    {
       
        if (isGrounded)
        {
            playerAudio.Play();
            JumpButtonChk = true;
            playerRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

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
    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        
    }
    
}
