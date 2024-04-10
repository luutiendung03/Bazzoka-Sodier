using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubber_Bullet : Bullet
{
    private bool isCollide = false;
    [SerializeField] private Grenade_Bullet bazooka_Bullet;
    [SerializeField] private float extraForce;

    public override void Explosion()
    {
        Desactivate();

        Bullet newBullet1 = Instantiate(bazooka_Bullet, point.position, Quaternion.identity);
        //newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
        newBullet1.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.down);

        Bullet newBullet2 = Instantiate(bazooka_Bullet, point.position, Quaternion.identity);
        //newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
        newBullet2.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.left);

        Bullet newBullet3 = Instantiate(bazooka_Bullet, point.position, Quaternion.identity);
        //newBullet3.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
        newBullet3.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.right);

        Bullet newBullet4 = Instantiate(bazooka_Bullet, point.position, Quaternion.identity);
        //newBullet4.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
        newBullet4.GetComponent<Rigidbody2D>().AddForce(extraForce * (new Vector2(-0.7f, -0.7f).normalized));

        Bullet newBullet5 = Instantiate(bazooka_Bullet, point.position, Quaternion.identity);
        //newBullet5.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
        newBullet5.GetComponent<Rigidbody2D>().AddForce(extraForce * (new Vector2(0.7f, -0.7f).normalized));

       
    }

    public override IEnumerator Explosion1()
    {
        yield return null;
    }

    //public override void Shoot(Bullet bullet, Vector2 point, Vector2 force)
    //{
        
    //    StartCoroutine(Shoot1(bullet, point, force));
    //}

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {
        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseRubber, 1);
        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.Push(force * direction);
        yield return new WaitForSeconds(2);

        Separation(newBullet);
    }

    private void Separation(Bullet newBullet)
    {
        if(newBullet.isActiveAndEnabled)
        {
            newBullet.Desactivate();
            Bullet newBullet1 = Instantiate(bazooka_Bullet, newBullet.transform.position, Quaternion.identity);
            //newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet1.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.down);

            Bullet newBullet2 = Instantiate(bazooka_Bullet, newBullet.transform.position, Quaternion.identity);
            //newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet2.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.left);

            Bullet newBullet3 = Instantiate(bazooka_Bullet, newBullet.transform.position, Quaternion.identity);
            //newBullet3.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet3.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.right);

            Bullet newBullet4 = Instantiate(bazooka_Bullet, newBullet.transform.position, Quaternion.identity);
            //newBullet4.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet4.GetComponent<Rigidbody2D>().AddForce(extraForce * (new Vector2(-0.7f, -0.7f).normalized));

            Bullet newBullet5 = Instantiate(bazooka_Bullet, newBullet.transform.position, Quaternion.identity);
            //newBullet5.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet5.GetComponent<Rigidbody2D>().AddForce(extraForce * (new Vector2(0.7f, -0.7f).normalized));
        }
        
    }
}
