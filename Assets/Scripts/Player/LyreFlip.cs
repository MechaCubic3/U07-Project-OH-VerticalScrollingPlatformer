using UnityEngine;


public class LyreFlip : MonoBehaviour
{

    public LayerMask groundLayer;

    public Vector2 boxSizeGround;

    public float castDistanceGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics2D.BoxCast(transform.position, boxSizeGround, 0, -transform.up, castDistanceGround, groundLayer))
        {
            gameObject.transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

    }



   


    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up * castDistanceGround, boxSizeGround);

    }


}
