using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky_Bullet : Bullet
{
    [SerializeField] private float scale;
    [SerializeField] private float duration;

    public override void Explosion()
    {

        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.DOScale(scale, duration).OnComplete(() => 
        {
            Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
            Explode();
            Desactivate();
        } );
        
        
    }

    public override IEnumerator Explosion1()
    {
        yield return null;
        
    }

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {
        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseSticky, 1);
        yield return null;
        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.Push(force * direction);
    }

    //public override void Shoot(Bullet bullet, Vector2 point, Vector2 force)
    //{
    //    Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
    //    newBullet.Push(force);
    //}
}
