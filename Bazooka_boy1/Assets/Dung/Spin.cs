using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public int numberofGift = 8;
    public float timeRotate;
    public float numberCircleRotate;

    private const float CIRCLE = 360.0f;
    private float angleOfOneGift;

    public Transform parent;
    private float currentTime;

    public AnimationCurve curve;

    private void Start()
    {
        angleOfOneGift = CIRCLE / numberofGift;
        SetPos();
    }

    IEnumerator WheelRotate()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;
        int indexGiftRandom = Random.Range(0, numberofGift);
        Debug.Log(indexGiftRandom + 1);

        float angleWant = (numberCircleRotate * CIRCLE) + angleOfOneGift * indexGiftRandom - startAngle + 20;

        while(currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWant * curve.Evaluate(currentTime / timeRotate );
            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent + startAngle);
        }
        int randomDistance = Random.Range(0, 40);
        //for (int i = 0; i <= randomDistance; i++)
        //{
        //    yield return new WaitForFixedUpdate();
        //    this.transform.eulerAngles = new Vector3(0, 0, 1);
        //}

    }    

    public void Rotate()
    {
        StartCoroutine(WheelRotate());
    }

    void SetPos()
    {
        for(int i=0; i<= parent.childCount; i++)
        {
            parent.GetChild(i).eulerAngles = new Vector3(0, 0, -CIRCLE / numberofGift * i );
            parent.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
        }
    }
}
