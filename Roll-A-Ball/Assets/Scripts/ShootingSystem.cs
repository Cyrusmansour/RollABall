using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float timerTotal = 5f;
    public float force;
    public GameObject prefab;
    public GameObject turret;
    float timerCurrent = 0f;

    void Start()
    {
        prefab = Resources.Load("Projectile") as GameObject;
    }

    void Update()
    {
        timerCurrent += Time.deltaTime;
        if (timerCurrent >= timerTotal)
        {
            GameObject Projectile = Instantiate(prefab) as GameObject;
            Projectile.transform.position = transform.position + turret.transform.forward * 2;
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.velocity = -(turret.transform.forward) * force;
            timerCurrent -= timerTotal;
        }
    }
}