using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cluster_Bullet : Bullet
{
    [SerializeField] private float force;
    [SerializeField] private Bazooka_Bullet banana;
    public override void Explosion()
    {
        Bazooka_Bullet banana1 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana1.GetComponent<Rigidbody2D>().AddForce(force * Vector2.right);

        Bazooka_Bullet banana2 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana2.GetComponent<Rigidbody2D>().AddForce(force * (new Vector2(0.87f, 0.48f).normalized));

        Bazooka_Bullet banana3 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana3.GetComponent<Rigidbody2D>().AddForce(force * Vector2.left);

        Bazooka_Bullet banana4 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana4.GetComponent<Rigidbody2D>().AddForce(force * (new Vector2(0.7f, 0.7f).normalized));

        Bazooka_Bullet banana5 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana5.GetComponent<Rigidbody2D>().AddForce(force * (new Vector2(-0.48f, 0.87f).normalized));

        Bazooka_Bullet banana6 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana6.GetComponent<Rigidbody2D>().AddForce(force * (new Vector2(0.48f, 0.87f).normalized));

        Bazooka_Bullet banana7 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana7.GetComponent<Rigidbody2D>().AddForce(force * (new Vector2(0.7f, 0.7f).normalized));

        Bazooka_Bullet banana8 = Lean.Pool.LeanPool.Spawn(banana, point.position, Quaternion.identity);
        banana8.GetComponent<Rigidbody2D>().AddForce(force * (new Vector2(0.87f, 0.48f).normalized));

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

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseCluster, 1);
    }

    //public override void Shoot(Bullet bullet, Vector2 point, Vector2 force)
    //{
    //    Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
    //    newBullet.Push(force);
    //}
}
