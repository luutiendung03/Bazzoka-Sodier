using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
    [SerializeField] private GameObject win_ProgressMap;
    [SerializeField] private GameObject win_Bonus;

    private bool luckyArrow = true  ;

    [SerializeField] private RectTransform arrow;

    private void Start()
    {
        StartCoroutine(LuckyBonousGold());
    }

    [SerializeField] private Image[] progressMap;
    private int currentProgressMap;
    public void Show()
    {
        PlayerPersistentData.Instance.Gold += 100;
        PlayerPersistentData.Instance.CurrentLevel++;
        gameObject.SetActive(true);
        Progress();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void WacthAds()
    {
        PlayerPersistentData.Instance.Gold += 100;
        NextLevel();
    }

    public void LoseIt()
    {
        win_ProgressMap.SetActive(false);
        win_Bonus.SetActive(true);
    }

    private void Progress()
    {
        currentProgressMap = PlayerPersistentData.Instance.CurrentLevel % 10;
        for(int i =0; i < currentProgressMap - 1; i++)
        {
            progressMap[i].enabled = true;
        }
    }    

    private IEnumerator LuckyBonousGold()
    {
        while(luckyArrow)
        {
            if (arrow.rotation.z == -11.5f)
            {
                for (float i = -11.5f; i <= 11.5; i += 0.5f)
                {
                    yield return new WaitForFixedUpdate();
                    arrow.rotation = new Quaternion(arrow.rotation.x, arrow.rotation.y, i, arrow.rotation.w);
                    if (!luckyArrow)
                        break;
                }
            }
            else if (arrow.rotation.z == 11.5f)
            {
                for (float i = 11.5f; i >= -11.5f; i -= 0.5f)
                {
                    yield return new WaitForFixedUpdate();
                    arrow.rotation = new Quaternion(arrow.rotation.x, arrow.rotation.y, i, arrow.rotation.w);
                    if (!luckyArrow)
                        break;
                }
            }
        }
    }

    public void ClaimGoldBonus()
    {
        luckyArrow = false;
    }

}
