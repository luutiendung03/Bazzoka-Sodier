using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Bullet : Bullet
{
    private int count = 0;
    public override void Explosion()
    {
        Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
        Explode();
        count++;
        if (count == 3)
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

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseBounce, 1);
    }


    //public override void Shoot(Bullet bullet, Vector2 point, Vector2 force)
    //{
    //    Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
    //    newBullet.Push(force);
    //}
}
