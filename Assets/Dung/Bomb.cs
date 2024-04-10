using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	[SerializeField ] private float explodeForce;
	[SerializeField] private float radius;
	[SerializeField] private GameObject explosion;

	private bool isExplosion = true;

	private GameObject theFirst;

	public void Explosion()
    {
		if(isExplosion)
        {
			isExplosion = false;
			Explode();
			gameObject.SetActive(false);
		}			
		
	}

	private void Explode()
    {
		AudioController.Instance.PlayAudio(0);
		Instantiate(explosion, transform.position, Quaternion.identity);

		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (Collider2D hit in colliders)
		{
			Rigidbody2D rb = hit.GetComponentInParent<Rigidbody2D>();



			if (rb != null && rb.gameObject.layer != 6)
			{
				Vector2 directionExplode = rb.position - (Vector2)transform.position;
				//Vector2 directionExplode1 = hit.offset - (Vector2)point.position;
				rb.AddForce(explodeForce * directionExplode.normalized);
				//Debug.Log(rb.name);
				if(rb.tag == "Player")
				{
					rb.GetComponent<Player>().CheckDead();
				}
				else if(rb.tag == "Enemy")
				{
					rb.GetComponent<Enemy>().CheckDead();
				}
                else if(rb.tag == "Barrel")
                {
					print("bcd");
					hit.GetComponent<Bomb>().Explosion();
				}
            }

		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		Explosion();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		//if (!firstCollide)
		//{
		//	theFirst = collision.gameObject;
		//	firstCollide = true;
		//}

		//if (collision.gameObject != theFirst)
		//{
		//	Explode();
		//	gameObject.SetActive(false);
		//}

		

		float magOfVelo = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
		if(collision.relativeVelocity.magnitude > 5)
        {
			Explosion();
        }
	}
}
