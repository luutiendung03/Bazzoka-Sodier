using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka_Bullet : Bullet
{
	

	public override void Explosion()
	{

		//Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
		Instantiate(explosion, point.position, Quaternion.identity);
		Explode();
		Desactivate();
		
	}

	public override IEnumerator Explosion1()
	{
		yield return null;
	}

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)	
    {
		yield return null;
		Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
		newBullet.Push(force * direction);
	}

    //  public override void Shoot(Bullet bullet, Vector2 point, Vector2 force)
    //  {
    //Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
    //newBullet.Push(force);
    //  }
    

}
