using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Singleton<Level>
{

    public Player player;
    public Enemy[] enemies;

    public int cnt = 0;
    [SerializeField] private int aOE = 0;
    private void Awake()
    {
        isEndGame = false;
        cnt = 0;
        aOE = 0;
        player = FindObjectOfType<Player>();

        enemies = FindObjectsOfType<Enemy>();
        for(int i =0; i< enemies.Length; i++)
        {
            if (enemies[i].enabled == true)
            {
                aOE++;
            }
            else
            {
                RemoveAt(ref enemies, i );
                i--;
            }
        }
        foreach (Enemy enemy in enemies)
        {
            
        }
    }



    public bool isEndGame = false;
    private IEnumerator LoseDead()
    {
        Debug.Log("Defeat");
        isEndGame = true;
        foreach (Enemy enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>() != null)
            {
                if (enemy.enabled == true)
                {
                    if (!enemy.isDead)
                        enemy.VictoryAnimation();
                }
            }

        }

        yield return new WaitForSeconds(2);
        UIManager.Instance.lose_Dead.Show();
    }

    void RemoveAt<T>(ref T[] array, int index)
    {
        for (int i = index; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        System.Array.Resize(ref array, array.Length - 1);
    }
    private IEnumerator LoseOutofBullet()
    {
        Debug.Log("Defeat");
        isEndGame = true;
        foreach (Enemy enemy in enemies)
        {
            
            if (enemy.enabled == true)
            {
                if (!enemy.isDead)
                    enemy.VictoryAnimation();
                Debug.Log(enemy.name);
            }
        }
        yield return new WaitForSeconds(2);
        UIManager.Instance.lose_OutOfBullet.Show();
    }

    public void LoseGame()
    {


    }



    private IEnumerator Victory()
    {
        Debug.Log("Victory");
        isEndGame = true;
        player.VictoryAnimation();
        yield return new WaitForSeconds(2);
        WinGame();
        if (GameManager.Instance.count == 2)
        {
            PlayerPersistentData.Instance.ScoreProgress(AchievementType.Oneshot, 1);
        }
    }

    public void WinGame()
    {
        UIManager.Instance.winProgress.Show();
    }

    private IEnumerator CheckWinLose()
    {
        isEndGame = true;
        yield return new WaitForSeconds(3);
        if (!player.isDead)
        {
            StartCoroutine(Victory());
        }
        else
        {
            StartCoroutine(LoseDead());

        }
    }

    private IEnumerator OutofBullet()
    {
        isEndGame = true;
        yield return new WaitForSeconds(5);
        if (player.isDead)
        {
            StartCoroutine(LoseDead());
        }
        else if (cnt == aOE)
        {
            StartCoroutine(Victory());
        }
        else
        {
            StartCoroutine(LoseOutofBullet());
        }
    }

    public void CheckWinorLose()
    {

        if (!isEndGame)
        {

            if (cnt >= aOE)
            {
                Debug.Log(enemies.Length);
                StartCoroutine(CheckWinLose());
            }

            if (player.isDead)
            {
                StartCoroutine(LoseDead());
            }

            if (GameManager.Instance.count == 0)
            {
                StartCoroutine(OutofBullet());
            }
        }
    }
}
