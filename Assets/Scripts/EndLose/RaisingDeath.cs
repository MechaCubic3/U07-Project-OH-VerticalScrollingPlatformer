using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

public class RaisingDeath : MonoBehaviour
{
   
    
  

    public float speed;

    public GameObject self;

    private bool stopIntent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {

        killingIntent = IntentToSee;

       stopIntent = true;

        self.SetActive(false);

        self.SetActive(true);
    }

    void Awake()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        if (self == true)
        {
            StartCoroutine(DelayFloor());
        }
        else if (self == false)
        {
            StopCoroutine(DelayFloor());
        }
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            Debug.Log("Player Touch");
            onPlayerDeath.Invoke();

        }
    }

    private void IntentToSee()
    {
        stopIntent = false;
    }

    IEnumerator DelayFloor()
    {
        yield return new WaitForSecondsRealtime(2);

        if (stopIntent)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
       

    }
}
