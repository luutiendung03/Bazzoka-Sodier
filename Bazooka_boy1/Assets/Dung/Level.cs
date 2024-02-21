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
		
		yield return new WaitForSeconds(5);
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

		yield return new WaitForSeconds(5);
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
	}

	public void WinGame()
	{
		UIManager.Instance.winProgress.Show();
	}

	public void CheckWinorLose()
	{

		if(!isEndGame)	
        {
			
			if (cnt == enemies.Length)
            {
				StartCoroutine(Victory());
			}				
				
			if (player.isDead)
			{
				StartCoroutine(LoseDead());
			}

			if(GameManager.Instance.count == 0)
            {
				StartCoroutine(LoseOutofBullet());
            }
		}
	}
}
