using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Bullet : Bullet
{
    public override void Explosion()
    {
        StartCoroutine(Explosion1());
    }

    public override IEnumerator Explosion1()
    {
        yield return new WaitForSeconds(2);
        Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
        Explode();
        Desactivate();
    }

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {
        yield return null;
        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.Push(force * direction);

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseGrenade, 1);
    }

    //public override void Shoot(Bullet bullet, Vector2 point, Vector2 force)
    //{
    //    Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
    //    newBullet.Push(force);
    //}
}
