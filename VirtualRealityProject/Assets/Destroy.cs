using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<bullet>() != null)
        {
            Destroy(gameObject);
            return;
        }
    }
        
}
