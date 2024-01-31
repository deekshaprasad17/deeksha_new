using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    private void OnCollisonEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Slime"))
        {
            Destroy(collision.gameObject);
        }
    }
}
