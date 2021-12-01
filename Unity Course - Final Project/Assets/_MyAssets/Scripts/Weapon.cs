using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform Camera;
    public Transform FirePoint;
    public ParticleSystem MuzzleFlash;

    BulletPool _bulletPool;

    [SerializeField] private bool _isShooting;
    [SerializeField] private float _bulletSpeed = 10;
    [SerializeField] private float _fireDelay;
    [SerializeField] private float _fireTimer;


    void Start()
    {
        _bulletPool = BulletPool.Instance;
    }

    void Update()
    {
        if (_isShooting)
        {
            //if (_fireTimer > 0)
            //{
            //    _fireTimer -= Time.deltaTime;
            //}
            //else
            //{
            //    _fireTimer = _fireDelay;
            //    Shoot();
            //}
        }
    }

    public void Shoot()
    {
        Vector3 bulletVelocity = Camera.forward * _bulletSpeed;
        _bulletPool.PickFromPool(FirePoint.position, bulletVelocity);
        MuzzleFlash.Play();
        Debug.Log("I am shooting!");
    }

    public void PullTrigger()
    {
        // Automate
        //if (_fireDelay > 0)
        _isShooting = true;
        //else
        Shoot();
    }

    public void ReleaseTrigger()
    {
        _isShooting = false;
        
        //_fireTimer = 0f;
    }
}