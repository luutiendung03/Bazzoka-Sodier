using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger_Bullet : Bullet
{
    private int cnt = 0;
    [SerializeField] private float forceScale;
    [SerializeField] private AnimationCurve curve;

    private float speed = 1;
    public override void Explosion()
    {
        Lean.Pool.LeanPool.Spawn(explosion, point.position, Quaternion.identity);
        Explode();
        cnt++;
        if(cnt ==4)
            Desactivate();
    }

    public override IEnumerator Explosion1()
    {
        yield return null;
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

            newBullet.transform.position += (velo * Time.deltaTime );

            Debug.Log(speed);
            veloY += (g * Time.deltaTime );
        }

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseDigger, 1);
        //Debug.Log("kewk");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explosion();
    }


}
