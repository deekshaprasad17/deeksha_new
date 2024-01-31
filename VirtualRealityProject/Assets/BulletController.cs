using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float dieTime = 5f;
    public GameObject collisionExplosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dieTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion,5f);
        return;

    }

}
