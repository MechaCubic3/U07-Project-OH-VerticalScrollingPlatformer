using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

public class MuseBodyGraphic : MonoBehaviour
{
    public float speed;

    private bool iWantToSee = true;



    private void Start()
    {
        stopsToLook = IWantToSee;
    }

    void Update()
    {
        StartCoroutine(DelayFloor());
    }

    IEnumerator DelayFloor()
    {
        yield return new WaitForSecondsRealtime(0);

        if (iWantToSee)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        

    }

    private void IWantToSee()
    {
        iWantToSee = false;
    }
}
