using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Transform teleport;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Vector2.Distance(collision.transform.position, transform.position) > 0.3f)
        {
            collision.gameObject.transform.position = teleport.position;
        }

    }

}
