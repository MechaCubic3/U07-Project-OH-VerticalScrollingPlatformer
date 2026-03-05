using UnityEngine;

public class MenuMuse : MonoBehaviour
{
    public Transform pointA;

    public Transform pointB;

    public float moveSpeed;

    private Vector3 mextPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mextPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mextPosition, moveSpeed * Time.deltaTime);

        if(transform.position == mextPosition)
        {
            mextPosition = (mextPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }
}
