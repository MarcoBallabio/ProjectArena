﻿using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    [SerializeField] private GameObject projectile;

    private ProjectileGun projectileGunScript;
    private float shotTime;
    private float projectileLifeTime;
    private float projectileSpeed;
    private bool shot;

    private void Update() {
        if (shot) {
            transform.position += transform.forward * Time.deltaTime * projectileSpeed;

            if (Time.time > shotTime + projectileLifeTime)
                Recover();
        }
    }

    // Sets the projectile.
    public void SetupProjectile(float plt, float ps, ProjectileGun pg) {
        projectileLifeTime = plt;
        projectileSpeed = ps;
        projectileGunScript = pg;
    }

    // Fires the projectile.
    public void Fire(Vector3 position, Quaternion direction) {
        transform.position = position;
        transform.rotation = direction;

        shot = true;
        shotTime = Time.time;
        gameObject.SetActive(true);
    }

    // Recovers the projectile.
    public void Recover() {
        shot = false;
        projectileGunScript.RecoverProjectile(gameObject);
        gameObject.SetActive(false);
    }



}
