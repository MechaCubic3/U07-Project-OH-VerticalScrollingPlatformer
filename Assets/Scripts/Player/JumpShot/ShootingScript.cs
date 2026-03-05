using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = 1f;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    //private GameObject bulletPrefab;
    private GameObject bulletObject;

    [SerializeField]
    private AudioClip _laserSoundClip;
    private AudioSource _audioSource;

    private void Start()
    {
        TryFire();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > _canFire)
            TryFire();
       
        

    }

    void TryFire()
    {
        _canFire = Time.time + _fireRate;
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bulletObject.transform.position = firePoint.position;
        bulletObject.transform.rotation = firePoint.rotation;

        bulletObject.SetActive(false);

        bulletObject.SetActive(true);


        if (bulletObject == null)
        {
            Debug.Log("bullet not assigned");
            return;
        }

        // if bullet is not active
            // set bullet position to firepoint
            // activate bullet
            // start bullet moving in target direction

    }

   
}
