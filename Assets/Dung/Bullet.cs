using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;
	
	[SerializeField] public GameObject explosion;
	[SerializeField] public Transform point;
	[SerializeField] public float radius;
	[SerializeField] public float explodeForce;

	[HideInInspector] public float veloX = 0;
	[HideInInspector] public float veloY = 0;

	public bool isCollision = false;




	//[HideInInspector] public Vector3 pos { get { return transform.position; } }

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CircleCollider2D>();
		
	}

	public void Push(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	public abstract IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force);

    void Update()
    {
		if(rb != null)
        {
			if (veloX == 0)
			{
				float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
			else
            {
				
				
			}
			
		}
		
    }

	public void Activate()
	{
		gameObject.SetActive(true);
	}

	public void Desactivate()
	{
		this.gameObject.SetActive(false);
	}
	public IEnumerator Desactivate1()
	{
		yield return new WaitForSeconds(1);
		gameObject.SetActive(false);
	}


	public abstract void Explosion();

	public void Explode()
    {
		AudioController.Instance.PlayAudio(0);
		Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, radius);
		foreach (Collider2D hit in colliders) 
		{
			Rigidbody2D rb = hit.GetComponentInParent<Rigidbody2D>();

			

			if (rb != null && rb.gameObject.layer != 6)
			{
				Vector2 directionExplode = rb.position - (Vector2)point.position;
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
                else if (rb.tag == "Barrel")
                {
					hit.GetComponent<Bomb>().Explosion();
                }
            }

		}
	}
	public abstract IEnumerator Explosion1();
    

	

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

		//gameObject.SetActive(false);
		
		//Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
		//Debug.Log(collision.contacts.Length);
	//}

    //   private void OnTriggerEnter2D(Collider2D collision)
    //   {
    //	gameObject.SetActive(false);
    //	//Instantiate(explosion, collision.transform.position, Quaternion.identity);
    //	//Debug.Log(collision.transform.position);
    //}
}
