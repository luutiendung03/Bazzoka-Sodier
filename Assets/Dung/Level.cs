using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Singleton<Level>
{

	public Player player;
	public Enemy[] enemies;

	public int cnt = 0;
    private void Start()
    {
		player = FindObjectOfType<Player>();

		enemies = FindObjectsOfType<Enemy>();
    }

    public bool isEndGame = false;
	private IEnumerator LoseDead()
	{
		Debug.Log("Defeat");
		isEndGame = true;
		foreach(Enemy enemy in enemies)
        {
			if(!enemy.isDead)
				enemy.VictoryAnimation();
		}			
		
		yield return new WaitForSeconds(2);
		UIManager.Instance.lose_Dead.Show();
	}

	private IEnumerator LoseOutofBullet()
	{
		Debug.Log("Defeat");
		isEndGame = true;
		foreach (Enemy enemy in enemies)
		{
			if (!enemy.isDead)
				enemy.VictoryAnimation();
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
		if(GameManager.Instance.count == 2)
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
		if(!player.isDead)
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
		if(player.isDead)
        {
			StartCoroutine(LoseDead());
		}
		else if(cnt == enemies.Length)
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

		if(!isEndGame)	
        {
			
			if (cnt >= enemies.Length)
            {
				StartCoroutine(CheckWinLose());
			}				
				
			if (player.isDead)
			{
				StartCoroutine(LoseDead());
			}

			if(GameManager.Instance.count == 0)
            {
				StartCoroutine(OutofBullet());
            }
		}
	}
}
