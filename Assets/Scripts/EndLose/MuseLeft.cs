using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;


public class MuseLeft : MonoBehaviour
{
    public float speed;

    private bool iWantToSee = true;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    //private GameObject bulletPrefab;
    private GameObject bulletObject;

    private bool isWalking = true;

    public float timer;

    private void Start()
    {
        stopsToLook = IWantToSee;
    }

    void Update()
    {
        
        if (isWalking)
        {
            StartCoroutine(DelayFloor());
            
        }
        if (iWantToSee)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }

    }

    IEnumerator DelayFloor()
    {
        isWalking = false;
        yield return new WaitForSecondsRealtime(timer);

        

        bulletObject.transform.position = firePoint.position;

        isWalking = true;

        StopCoroutine(DelayFloor());
    }

  

    private void IWantToSee()
    {
        iWantToSee = false;
    }
}