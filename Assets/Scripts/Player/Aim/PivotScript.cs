using UnityEngine;
using UnityEngine.UIElements;

public class PivotScript : MonoBehaviour
{
    public GameObject Mouse;

    public float speed;

    public float distanceBetween;

    public GameObject player;

    private float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Point();

        Children();

    }

    void Point()
    {
        distance = Vector2.Distance(transform.position, Mouse.transform.position);
        Vector2 direction = Mouse.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }
    }

    void Children()
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
