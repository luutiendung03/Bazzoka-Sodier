using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napalm_Bullet : Bullet
{
    public int cnt = 3;
    public Napalm_Bullet napalm;
    [SerializeField] private float extraForce;
    [SerializeField] private bool isCollide = false;



    public override void Explosion()
    {

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseNapalm, 1);

        if (cnt == 3)
        {
            Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
            


            Bullet newBullet1 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet1.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.down);
            newBullet1.GetComponent<Napalm_Bullet>().cnt = 2;


            Bullet newBullet2 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet2.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.left);
            newBullet2.GetComponent<Napalm_Bullet>().cnt = 2;

            Bullet newBullet3 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet3.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet3.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.right);
            newBullet3.GetComponent<Napalm_Bullet>().cnt = 2;

            //this.gameObject.GetComponent<Destructible2D.D2dDestroyer>().enabled = true;
            Desactivate();
        }
        else if(cnt == 2)
        {
            Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
            

            Bullet newBullet1 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet1.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.down);
            newBullet1.GetComponent<Napalm_Bullet>().cnt = 1;


            Bullet newBullet2 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet2.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.left);
            newBullet2.GetComponent<Napalm_Bullet>().cnt = 1;

            Bullet newBullet3 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet3.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet3.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.right);
            newBullet3.GetComponent<Napalm_Bullet>().cnt = 1;

            Desactivate();
        }
        else if(cnt ==1)
        {
            Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
            

            Bullet newBullet1 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet1.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.down);
            newBullet1.GetComponent<Napalm_Bullet>().cnt = 0;


            Bullet newBullet2 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet2.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.left);
            newBullet2.GetComponent<Napalm_Bullet>().cnt = 0;

            Bullet newBullet3 = Instantiate(napalm, point.position, Quaternion.identity);
            //newBullet3.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet3.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.right);
            newBullet3.GetComponent<Napalm_Bullet>().cnt = 0;

            Desactivate();
        }
        else if(cnt == 0)
        {
            Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
            Desactivate();
        }
    }

    public override IEnumerator Explosion1()
    {
        yield return null;
    }

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {
        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.Push(force * direction);
        yield return new WaitForSeconds(2);

        Separation(newBullet);
    }

    private void Separation(Bullet newBullet)
    {
        if (newBullet.isActiveAndEnabled)
        {

            newBullet.Desactivate();

            Bullet newBullet1 = Instantiate(napalm, newBullet.transform.position, Quaternion.identity);

            newBullet1.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet1.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.down);
            newBullet1.GetComponent<Napalm_Bullet>().cnt = 2;


            Bullet newBullet2 = Instantiate(napalm, newBullet.transform.position, Quaternion.identity);
            newBullet2.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet2.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.left);
            newBullet2.GetComponent<Napalm_Bullet>().cnt = 2;

            Bullet newBullet3 = Instantiate(napalm, newBullet.transform.position, Quaternion.identity);
            newBullet3.GetComponent<Rigidbody2D>().velocity = newBullet.GetComponent<Rigidbody2D>().velocity;
            newBullet3.GetComponent<Rigidbody2D>().AddForce(extraForce * Vector2.right);
            newBullet3.GetComponent<Napalm_Bullet>().cnt = 2;
        }
    }    
}
