using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public bool createForce = true;
    public bool shouldExplode = false;
    public float lifeTime = 10f;

    public float power = 10.0f;
    public float radius = 5.0f;
    public float upwardsThrust = 3.0f;

    public GameObject explosion;
    private Collider[] overlappers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime>0)
        {
            lifeTime-=(Time.deltaTime);
            if(lifeTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
     void FixedUpdate()
        {
        if (createForce)
        {
            rb.AddForce(transform.forward * thrust);
            createForce = false;
        }

        if (shouldExplode)
        {
            Collider[] colliders = GetOverlappers();

            foreach(Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if(rb!= null)
                {
                    rb.AddExplosionForce(power, this.transform.position, radius, upwardsThrust);
                }
            }
            Destroy(this.gameObject );
        }
        }

    private void OnCollisionEnter(Collision coll)
    {
        shouldExplode = true;
        Instantiate(explosion, this.transform.position, this.transform.rotation);
    }

    Collider[] GetOverlappers()
    {
        return Physics.OverlapSphere(this.transform.position, radius);
    }
}

