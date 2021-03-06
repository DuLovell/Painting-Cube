using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float rapidity;

    Timer shotTimer;

    private void Awake()
    {
        shotTimer = gameObject.AddComponent<Timer>();
    }

    private void Start()
    {
        shotTimer.Duration = rapidity;
        shotTimer.Run();
    }

    private void Update()
    {
        if (shotTimer.Finished)
        {
            Fire();
            shotTimer.Run();
        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
