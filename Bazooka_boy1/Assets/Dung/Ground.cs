using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField ] private GameObject explosion;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosion, collision.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate(explosion, collision.transform.position, Quaternion.identity);
        //Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
    }
}
