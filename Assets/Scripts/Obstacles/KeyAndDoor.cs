using UnityEngine;

public class KeyAndDoor : MonoBehaviour
{
    public Vector2 groundCheckSize;
    public float castDistance;
    public LayerMask groundLayer;
    public LayerMask doorLayer;

    public float speed;

    public float distanceBetween;

    public GameObject player;

    private float distance;

    private bool HaveKey = false;

    [SerializeField]
    private GameObject Door;

    [SerializeField]
    private GameObject Key;

    // Update is called once per frame
    void Update()
    {
        if (UnlockDoorLock() == true)
        {
            HaveKey = true;
        }

        if (UnlockDoorLockReal() == true)
        {
            Door.SetActive(false);
            Key.SetActive(false);
            Debug.Log("DoorUnlocked");
        }

        if (HaveKey)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();


            if (distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            }
        }

        
    }

   

    public bool UnlockDoorLock()
    {
        if (Physics2D.BoxCast(transform.position, groundCheckSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UnlockDoorLockReal()
    {
        if (Physics2D.BoxCast(transform.position, groundCheckSize, 0, -transform.up, castDistance, doorLayer))
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
