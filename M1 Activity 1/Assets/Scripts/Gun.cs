using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;       
    public Transform bulletSpawnPoint;   
    public float bulletSpeed = 20f;      
    public float fireRate = 0.2f;        
    private float nextFireTime = 0f;     

    void Update()
    {
     
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        Debug.Log("Bullet fired");
        Destroy(bullet, 3f);
    }
}
