using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber : MonoBehaviour
{
   public RubberShape Shape { set { shape = value; } get { return shape; } }
    [SerializeField] private RubberShape shape = RubberShape.Square;

    [SerializeField] private float force;
    //[SerializeField ] private 
    
    private void ElasticForce(Rigidbody2D rigid, float force)
    {

        float x = rigid.velocity.normalized.x;
        float y = rigid.velocity.normalized.y;
        
        Debug.Log(rigid.velocity);
        switch (shape)
        {
            case RubberShape.Square:
                rigid.velocity = (force * new Vector2(x, -y));
                break;

            case RubberShape.Triangle:
                rigid.velocity = (force * new Vector2(-x, -y));
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("kewk");
        if (collision.collider.tag != "Ground")
        {
            //Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
                ElasticForce(collision.gameObject.GetComponent<Rigidbody2D>(), force);
        }
    }

}

public enum RubberShape
{
    Square,
    Triangle
}
