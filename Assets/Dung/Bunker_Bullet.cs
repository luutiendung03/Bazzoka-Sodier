using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker_Bullet : Bullet
{
    public GameObject bunkerExplosion;
    [SerializeField] private float forceScale = 5f;

    [SerializeField] private float speed = 1;


    public override void Explosion()
    {
        StartCoroutine(Explosion1());
    }

    public override IEnumerator Explosion1()
    {
        Lean.Pool.LeanPool.Spawn(bunkerExplosion, point.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
        Explode();
        Desactivate();
    }


    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {
        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        //forceScale = newBullet.GetComponent<Rigidbody2D>().mass;
        //newBullet.Push(force * direction * forceScale);
        //newBullet.GetComponent<Rigidbody2D>().velocity = force * direction;
        //Debug.Log(Time.deltaTime);
        //float y = curve.Evaluate(1);

        float veloX = force * forceScale * direction.x;
        float veloY = force * forceScale * direction.y;
        float t = Time.deltaTime;
        float g = Physics2D.gravity.y;

        for (float i = 0; i < 100; i += 0.05f)
        {
            yield return null;
            Vector3 velo = new Vector3(veloX, veloY);

            float angle = Mathf.Atan2(veloY, veloX) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (newBullet.isCollision)
                speed = 0.2f;
            else
                speed = 1;
            newBullet.transform.position += (velo * Time.deltaTime * speed);

            //Debug.Log(speed);
            veloY += (g * Time.deltaTime * speed);
        }

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseBunker, 1);
        //Debug.Log("kewk");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollision = true;
        StartCoroutine(Explosion1());
        Debug.Log("1");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isCollision = true;
    //    StartCoroutine(Explosion1());
    //    Debug.Log("1");
    //}
}

