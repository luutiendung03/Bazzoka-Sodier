using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst_Bullet : Bullet
{
    public override void Explosion()
    {
        Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
        Explode();
        Desactivate();
    }

    public override IEnumerator Explosion1()
    {
        yield return null;
    }

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {
        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseBurst, 1);

        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.Push(force * direction);
        yield return new WaitForSeconds(0.2f);

        Bullet newBullet1 = Instantiate(bullet, point, Quaternion.identity);
        newBullet1.Push(force * direction);
        yield return new WaitForSeconds(0.2f);

        Bullet newBullet2 = Instantiate(bullet, point, Quaternion.identity);
        newBullet2.Push(force * direction);
    }
}
