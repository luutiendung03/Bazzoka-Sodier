using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Bullet : Bullet
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
        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseShotgun, 1);

        yield return null;
        float a = 0;
        if (direction.y != 0)
            a = (Mathf.Atan(direction.x/direction.y)) * Mathf.Rad2Deg;
        Vector2 newDirection = new Vector2(Mathf.Tan(Random.Range(a - 15, a + 15) * Mathf.Deg2Rad), 1);

        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.Push(Random.Range(force - 1, force + 1) * new Vector2(Mathf.Tan(Random.Range(a - 5, a + 5) * Mathf.Deg2Rad), 1).normalized);
        Bullet newBullet1 = Instantiate(bullet, point, Quaternion.identity);
        newBullet1.Push(Random.Range(force - 1, force + 1) * new Vector2(Mathf.Tan(Random.Range(a - 5, a + 5) * Mathf.Deg2Rad), 1).normalized);
        Bullet newBullet2 = Instantiate(bullet, point, Quaternion.identity);
        newBullet2.Push(Random.Range(force - 1, force + 1) * new Vector2(Mathf.Tan(Random.Range(a - 5, a + 5) * Mathf.Deg2Rad), 1).normalized);
        Bullet newBullet3 = Instantiate(bullet, point, Quaternion.identity);
        newBullet3.Push(Random.Range(force - 1, force + 1) * new Vector2(Mathf.Tan(Random.Range(a - 5, a + 5) * Mathf.Deg2Rad), 1).normalized);
        Bullet newBullet4 = Instantiate(bullet, point, Quaternion.identity);
        newBullet4.Push(Random.Range(force - 1, force + 1) * new Vector2(Mathf.Tan(Random.Range(a - 5, a + 5) * Mathf.Deg2Rad), 1).normalized);
    }
}
