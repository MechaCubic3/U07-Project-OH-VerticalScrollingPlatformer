
using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    

    public float moveSpeed;

    public float acceleration;

    public float decceleration;

    public float velPower;

    private Rigidbody2D rb;
    private float horizontal;

    public float jumpForce;
    public float jumpCutForce;

    private bool isJumping;

    public Vector2 groundCheckSize;
    public float castDistance;
    public LayerMask groundLayer;
    
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
       
    }


    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Anima();

        Jump();


      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        



        

        float targetSpeed = horizontal * moveSpeed;

        float speedDif = targetSpeed - rb.linearVelocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

        float movement =  Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);


        rb.AddForce(movement * Vector2.right);



        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
           
        }
        if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            
        }



    }

  

    public bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position, groundCheckSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   

    public void Jump()
    {
        if (IsGrounded() == true && Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isJumping = true;
            
        }
       


        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {

            rb.AddForce(Vector2.down * jumpCutForce, ForceMode2D.Impulse);

        }
    }

  
    public void Anima()
    {
        if (horizontal != 0)
        {
            animator.SetBool("isRunning", true);
           
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            animator.SetBool("isLookingUp", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            animator.SetBool("isLookingUp", false);
        }


        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            animator.SetBool("isLookingDown", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            animator.SetBool("isLookingDown", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) )
        {

            animator.SetBool("isJump", true);

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJump", false);
        }
       
        if (IsGrounded())
        {
            animator.SetBool("hitFloor", true);
        }
        else
        {
            animator.SetBool("hitFloor", false);
        }



    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, groundCheckSize);
    }












}
