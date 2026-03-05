using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

public class MuseGraphics : MonoBehaviour
{

    public float speed;

    public float distanceBetween;

    public GameObject player;

    private float distance;

    private bool stopDis = true;

    public float newSpeed;

    public float oldSpeed;

    public float alphaLevel = 1f;

    private bool pillarOffIn;

    private bool pillarWait = false;

    private void Start()
    {
        pillarOffIn = true;

        pillarOff = PillarOffFunk;

        StartCoroutine(DelayFloor());
    }

    

    private void Update()
    {
        
        if ((stopDis) && pillarOffIn && pillarWait)
        {
            FollowAtDistance();
            //Debug.Log("Pillar On true");
        }

        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);

       
    }

    IEnumerator DelayFloor()
    {
        yield return new WaitForSecondsRealtime(1);

        pillarWait = true;

    }

    private void PillarOffFunk()
    {
        pillarOffIn = false;
    }

    public void FollowAtDistance()
    {

       
            Vector2 newPosition = transform.position;

            newPosition.x = Mathf.MoveTowards(transform.position.x, player.transform.position.x, speed);

            transform.position = newPosition;

            //Debug.Log("Pillar On");




    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {


        if (collider2D.CompareTag("StopField"))
        {
           stopDis = false;
        }

        if (collider2D.CompareTag("Player"))
        {
            stopDis = false;
            alphaLevel -= 0.7f;
        }

        if (collider2D.CompareTag("SlowField"))
        {
            speed = newSpeed;
        }

    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("StopField"))
        {
            stopDis = true;
        }

        if (collider2D.CompareTag("Player"))
        {
            
            alphaLevel += 0.7f;
        }

        if (collider2D.CompareTag("SlowField"))
        {
            speed = oldSpeed;
        }
    }


}
