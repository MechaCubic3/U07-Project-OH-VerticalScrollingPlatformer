using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpProjectile : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1.0f;

    // timeout delay

    public GameObject bulletObject;

    public Vector2 boxSizeGround;

    public float castDistanceGround;

    public LayerMask groundLayer;

    private BoxCollider2D bc;

    private Animator animator;



    private void Awake()
    {
        
        bulletObject.SetActive(false);

        bc = GetComponent<BoxCollider2D>();

        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        bc.enabled = false;

        StartCoroutine(Delay());

        animator.SetBool("isRed", true);

    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(0.6f);

        animator.SetBool("isRed", false);
        bc.enabled = true;

    }

    private void Update()
    {

        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (noJumping())
        {
           
        }

       
        
    }

    public bool noJumping()
    {
        if (Physics2D.BoxCast(transform.position, boxSizeGround, 0, -transform.up, castDistanceGround, groundLayer))
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
        Gizmos.DrawCube(transform.position - transform.up * castDistanceGround, boxSizeGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag == "Player")
        {
            //Destroy(this.gameObject);
            StartCoroutine(Delay2());
            animator.SetBool("isRed", true);
        }
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSecondsRealtime(0.6f);


        bulletObject.SetActive(false);

    }
}

// after activation, start delay timer
// deactivate when timer finishes