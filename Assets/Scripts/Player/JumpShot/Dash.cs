using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Dash : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField] private float dashingVelocity;
    [SerializeField] private float dashingTime;
    private Vector2 dashingDir;
    private bool isDashing;
   
    public float coyoteTimeCounter;

    public float coyoteTime;

    public Vector2 groundCheckSize;
    public float castDistance;
    public LayerMask groundLayer;
    
    private bool wasGrounded;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {

        JumpFunk();


    }


    public void JumpFunk()
    {
        var dashInput = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A);
          
        if (coyoteTimeCounter > 0f && dashInput && isDashing == false)
        {
            isDashing = true;

           

            dashingDir = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
            if (dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, y: 0);
            }

            StartCoroutine(StopDashing());
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            coyoteTimeCounter = 0f;
        }

        if (isDashing)
        {
            rb.linearVelocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
           coyoteTimeCounter -= Time.deltaTime;
        }



    }


   

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;

      
        
    }


    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, groundCheckSize, 0, -transform.right, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, groundCheckSize);
    }
}
