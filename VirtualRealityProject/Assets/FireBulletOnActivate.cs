using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    private AudioSource bulletsound;


    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        bulletsound = GetComponent<AudioSource>();
    }

    

    public void FireBullet(ActivateEventArgs args)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;     
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward *  fireSpeed;
        Destroy(spawnedBullet,5);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bulletsound.Play();
        }
    }

}
