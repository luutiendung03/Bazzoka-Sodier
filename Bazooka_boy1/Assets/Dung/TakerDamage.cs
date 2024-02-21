using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakerDamage : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
    }
}
