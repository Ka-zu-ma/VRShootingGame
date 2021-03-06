﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour {
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public AudioClip fire;
    public AudioSource source;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    void Start() {
        Debug.Log("Startの中");
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update() {
        //If you want a different input, change it here

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) {
            // 右人差し指トリガーを押したとき
            //Calls animation on the gun that has the relevant animation events that will fire
            gunAnimator.SetTrigger("Fire");
            source.PlayOneShot(fire);
        }
        Debug.Log("Updateの中");
    }

    //This function creates the bullet behavior
    void Shoot() {
        Debug.Log("Shoot入った");
        Debug.Log(bulletPrefab.name, bulletPrefab);

        if (muzzleFlashPrefab) {
            //create the muzzle flash
            GameObject tempflash;
            tempflash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //destroy the muzzle flash effect
            Destroy(tempflash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab) { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Debug.Log("Shoot最後まできた");
    }

    //This function creates a casing at the ejection slot
    void CasingRelease() {
        Debug.Log("CasingReleas入った");
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab) { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
        Debug.Log("CasingReleas最後まできた");
    }

}