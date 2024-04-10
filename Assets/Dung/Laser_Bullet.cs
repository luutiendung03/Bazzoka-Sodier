using Destructible2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Bullet : Bullet
{

    [Tooltip("The layers the explosion should work on")]
    public LayerMask Mask = -1;

    [Tooltip("Sould the explosion stamp a shape?")]
    public bool Stamp = true;

    [Tooltip("The paint type.")]
    public D2dDestructible.PaintType StampPaint;

    [Tooltip("The shape of the stamp")]
    public Texture2D StampShape;

    [Tooltip("The stamp shape will be multiplied by this.\nSolid White = No Change")]
    public Color StampColor = Color.white;

    [Tooltip("The size of the explosion stamp in world space")]
    public Vector2 StampSize = new Vector2(1.0f, 1.0f);

    public override void Explosion()
    {

    }

    public override IEnumerator Explosion1()
    {
        yield return null;
    }

    public override IEnumerator Shoot(Bullet bullet, Vector2 point, Vector2 direction, float force)
    {

        var stampPosition = point;
        float stampAngle;
        float c = 0;

        if (direction.y != 0)
            c = direction.x / direction.y;
        float a = (-Mathf.Atan(c)) * Mathf.Rad2Deg;

        
        if (direction.y >= 0)
        {
            stampAngle = a;

        }
        else
        {
            stampAngle = a - 180;

        }
        Vector3 eula = new Vector3(0, 0, stampAngle );
        Bullet newBullet = Instantiate(bullet, point, Quaternion.identity);
        newBullet.transform.eulerAngles = eula;
        Debug.Log(newBullet.transform.eulerAngles);

        yield return new WaitForSeconds(1f);

        newBullet.Desactivate();

        if (Stamp == true)
        {
            All(StampPaint, point, StampSize, stampAngle, StampShape, StampColor, Mask);

        }

        PlayerPersistentData.Instance.ScoreProgress(AchievementType.UseLaser, 1);
    }

    Matrix4x4 CalculateMatrix(Vector2 position, Vector2 size, float angle)
    {
        var t = Matrix4x4.Translate(new Vector3(position.x, position.y, 0.0f));
        var r = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0.0f, 0.0f, angle), Vector3.one);
        var s = Matrix4x4.Scale(new Vector3(size.x, size.y, 1.0f));
        var o = Matrix4x4.Translate(new Vector3(-0.5f, 0f, 0.0f));

        return t * r * s * o;
    }

    void All(D2dDestructible.PaintType paint, Vector2 position, Vector2 size, float angle, Texture2D shape, Color color, int layerMask = -1)
    {
        All1(paint, CalculateMatrix(position, size, angle), shape, color, layerMask);
    }

    void All1(D2dDestructible.PaintType paint, Matrix4x4 matrix, Texture2D shape, Color color, int layerMask = -1)
    {
        var destructible = D2dDestructible.FirstInstance;

        for (var i = D2dDestructible.InstanceCount - 1; i >= 0; i--)
        {
            if (D2dHelper.IndexInMask(destructible.gameObject.layer, layerMask) == true)
            {
                destructible.Paint(paint, matrix, shape, color);
            }

            destructible = destructible.NextInstance;
        }
    }
}
