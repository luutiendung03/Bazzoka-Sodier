using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	[SerializeField ] private float explodeForce;
	[SerializeField] private float radius;
	[SerializeField] private GameObject explosion;

	private bool firstCollide = false;

	private GameObject theFirst;

	private void Explode()
    {
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
				if (rb.tag == "Player")
				{
					Player.Instance.CheckDead();
				}
				else if (rb.tag == "Enemy")
				{
					StartCoroutine(Enemy.Instance.Die());
				}
			}

		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (!firstCollide)
		{
			theFirst = collision.gameObject;
			firstCollide = true;
		}

		if (collision.gameObject != theFirst)
		{
			Explode();
			gameObject.SetActive(false);
		}
	}
}
