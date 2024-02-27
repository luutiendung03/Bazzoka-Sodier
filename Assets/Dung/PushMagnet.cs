using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushMagnet : MonoBehaviour
{
	[SerializeField] private float radius;
	[SerializeField] private float speed;

	private void Update()
	{
		Push();
	}
	public void Push()
	{

		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
		foreach (Collider2D hit in colliders)
		{
			Rigidbody2D rb = hit.GetComponentInParent<Rigidbody2D>();



			if (rb != null && rb.gameObject.layer == 6)
			{
				Vector2 direction = rb.position - (Vector2)transform.position;
				//Vector2 directionExplode1 = hit.offset - (Vector2)point.position;
				rb.velocity = speed * direction.normalized;
				//Debug.Log(rb.name);


			}

		}
	}
}
