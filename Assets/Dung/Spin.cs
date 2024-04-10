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

    public bool isSpin = false;

    [SerializeField] private GameObject gift;
    [SerializeField] private Text price;

    private void Start()
    {
        angleOfOneGift = CIRCLE / numberofGift;
        SetPos();
    }

    private bool isRotate = true;

    IEnumerator WheelRotate()
    {
        if(isRotate)
        {
            isRotate = false;
            float startAngle = gameObject.transform.GetChild(0).eulerAngles.z;
            currentTime = 0;
            int indexGiftRandom = Random.Range(0, numberofGift - 1);
            Debug.Log(indexGiftRandom + 1);

            float angleWant = (numberCircleRotate * CIRCLE) + angleOfOneGift * indexGiftRandom - startAngle;

            AudioController.Instance.PlayAudio(2);

            while (currentTime < timeRotate)
            {
                yield return new WaitForEndOfFrame();
                currentTime += Time.deltaTime;

                float angleCurrent = angleWant * curve.Evaluate(currentTime / timeRotate);
                gameObject.transform.GetChild(0).eulerAngles = new Vector3(0, 0, angleCurrent + startAngle);
            }
            int randomDistance = Random.Range(0, 40);
            //for (int i = 0; i <= randomDistance; i++)
            //{
            //    yield return new WaitForFixedUpdate();
            //    this.transform.eulerAngles = new Vector3(0, 0, 1);
            //}

            gift.SetActive(true);

            switch (indexGiftRandom)
            {
                case 0:
                    PlayerPersistentData.Instance.Gold += 50;
                    price.text = "50";
                    break;
                case 1:
                    PlayerPersistentData.Instance.Gold += 100;
                    price.text = "100";
                    break;
                case 2:
                    PlayerPersistentData.Instance.Gold += 150;
                    price.text = "150";
                    break;
                case 3:
                    PlayerPersistentData.Instance.Gold += 200;
                    price.text = "200";
                    break;
                case 4:
                    PlayerPersistentData.Instance.Gold += 2500;
                    price.text = "250";
                    break;
                case 5:
                    PlayerPersistentData.Instance.Gold += 300;
                    price.text = "3000";
                    break;
                case 6:
                    PlayerPersistentData.Instance.Gold += 350;
                    price.text = "350";
                    break;
                case 7:
                    PlayerPersistentData.Instance.Gold += 400;
                    price.text = "400";
                    break;
            }
        }
        
        isRotate = true;
    }    

    public void Rotate()
    {
        if(DateTimeController.Instance.CheckSpinDaily())
        {
            DateTimeController.Instance.SaveSpinTime();
            StartCoroutine(WheelRotate());
            
        }

    }

    public void CloseGIft()
    {
        gift.SetActive(false);
        AudioController.Instance.PlayAudio(3);
    }

    void SetPos()
    {
        for(int i=0; i< parent.childCount; i++)
        {
            parent.GetChild(i).eulerAngles = new Vector3(0, 0, -CIRCLE / numberofGift * i  );
            //parent.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
        }
    }
}
