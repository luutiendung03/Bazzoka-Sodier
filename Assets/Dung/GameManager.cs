using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	//Camera cam;

	public int count = 3;
	private int ads = 0;

	//public Bullet bullet;
	//public Trajectory trajectory;
	//[SerializeField] float pushForce;

	//bool isDragging = false;

	//Vector2 startPoint;
	//Vector2 endPoint;
	//Vector2 direction;
	//Vector2 force;
	//float distance;

	//public float a;
	//private float c;

	public Level curLevel;

	


	//---------------------------------------
	void Start()
	{
		
		
		//cam = Camera.main;
		//bullet.DesactivateRb();
		Physics2D.gravity = new Vector2(0, -10);
		LoadCurrentLevel();
	}

	void Update()
	{
		//if(count > 0 && !curLevel.isEndGame)
  //      {
		//	if (Input.GetMouseButtonDown(0))
		//	{
		//		isDragging = true;
		//		OnDragStart();
		//		UIScreenEvent.Instance.MenuOff();
		//	}
		//	if (Input.GetMouseButtonUp(0))
		//	{
		//		isDragging = false;
		//		OnDragEnd();
		//		count--;
		//	}

		//	if (isDragging)
		//	{
		//		OnDrag();
		//	}
		//}
		

		BulletCount();
		if(curLevel != null)
        {
			//curLevel = FindObjectOfType<Level>();
			curLevel.CheckWinorLose();
		}
		else
        {
			Debug.Log("ko co level");
        }
		
		StartCheckKill();
	}

	//-Drag--------------------------------------
	//void OnDragStart()
	//{
	//	//bullet.DesactivateRb();
	//	startPoint = cam.ScreenToWorldPoint(Input.mousePosition);


	//	trajectory.Show();
	//}

	//void OnDrag()
	//{
	//	endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
	//	//distance = Vector2.Distance(startPoint, endPoint);
	//	direction = (startPoint - endPoint).normalized;
	//	force = direction * pushForce;

	//	//just for debug
	//	Debug.DrawLine(startPoint, endPoint);

	//	if (direction.y != 0)
	//		c = direction.x / direction.y;
	//	a = (-Mathf.Atan(c)) * Mathf.Rad2Deg;

	//	if (direction.y >= 0)
	//	{

	//		if (direction.x >= 0)
	//           {
	//			Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) + new Vector3(0, 0, 90);
	//			Player.Instance.gun.localScale = new Vector3(1, 1, 1);
	//		}
	//           else 
	//		{
	//			Player.Instance.hip.eulerAngles = new Vector3(0, 0, -90 + a);
	//			Player.Instance.gun.localScale = new Vector3(-1, 1, 1);
	//			//Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) + new Vector3(0, 0, 90);
	//		}
	//	}
	//	else
	//	{

	//		if (direction.x >= 0)
	//		{
	//			Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) - new Vector3(0, 0, 90);
	//			Player.Instance.gun.localScale = new Vector3(1, 1, 1);
	//		}
	//		else
	//		{
	//			Player.Instance.hip.eulerAngles = new Vector3(0, 0, 90 + a);
	//			Player.Instance.gun.localScale = new Vector3(-1, 1, 1);
	//			//Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) - new Vector3(0, 0, 90);
	//		}
	//	}

	//	trajectory.UpdateDots(Player.Instance.scope.position, force);
	//}

	//void OnDragEnd()
	//{
	//	//push the ball
	//	//Bullet newBullet = Instantiate(bullet, Player.Instance.scope.position, Quaternion.identity);
	//	//newBullet.Push(direction * pushForce);

	//	StartCoroutine(bullet.Shoot(bullet, Player.Instance.scope.position, direction, pushForce));


	//	//bullet.Shoot(bullet, Player.Instance.scope.position, direction * pushForce); 

	//	trajectory.Hide();
	//}


	private int cntShoot;
	private int enemyDead;
	public bool shoot = true;
	private bool flag = true;
	private bool flag1 = true;

	private void StartCheckKill()
    {
		StartCoroutine(CheckKill());
    }		
	private IEnumerator  CheckKill()
    {
		
		if(shoot)
        {
			shoot = false;
			cntShoot = count;
			enemyDead = Level.Instance.cnt;
			
		}
		
		if(count == cntShoot)
        {
			if((Level.Instance.cnt - enemyDead == Level.Instance.enemies.Length) && flag)
            {
				flag = false;
				GamePlay.instance.aceTxt.SetActive(true);
				yield return new WaitForSeconds(1f);
				GamePlay.instance.aceTxt.SetActive(false);
			}
			if((Level.Instance.cnt - enemyDead == 2) && flag1)
            {
				flag1 = false;
				GamePlay.instance.dbKillText.SetActive(true);
				yield return new WaitForSeconds(1f);
				GamePlay.instance.dbKillText.SetActive(false); ;
			}
		}
    }

	public void GetMoreBullet()
    {
		GamePlay.instance.maxBullet.SetActive(true);
		count = 1000;
    }


	private void BulletCount()
	{
		if (count == 3)
		{
			GamePlay.instance.firstBullet.SetActive(true);
			GamePlay.instance.secondBullet.SetActive(true);
			GamePlay.instance.thirdBullet.SetActive(true);
		}
		if (count == 2)
		{
			GamePlay.instance.firstBullet.SetActive(true);
			GamePlay.instance.secondBullet.SetActive(true);
			GamePlay.instance.thirdBullet.SetActive(false);
		}
		if (count == 1)
		{
			GamePlay.instance.firstBullet.SetActive(true);
			GamePlay.instance.secondBullet.SetActive(false);
			GamePlay.instance.thirdBullet.SetActive(false);
		}
		if (count == 0)
		{
			GamePlay.instance.firstBullet.SetActive(false);
			GamePlay.instance.secondBullet.SetActive(false);
			GamePlay.instance.thirdBullet.SetActive(false);
		}

	}

	public  void PlayNormalMode()
    {

		UIScreenEvent.Instance.MenuOff();
	}


	float startTimePlay;


	public void LoadCurrentLevel()
	{
		
		bool hasLevel = HasLevelLeft();
		if (hasLevel)
		{
			LoadLevel();
		}
		else
		{
			Debug.Log("Het Level");
		}
	}

	public bool HasLevelLeft()
	{
		return Resources.Load<GameObject>("Levels/Level" + levelPlay);
	}

	public void LoadLevel()
	{
		levelPlay = (PlayerPersistentData.Instance.CurrentLevel % 30);
		UIManager.Instance.rate++;
		ads++;
		if (levelPlay == 0)
			levelPlay = 30;
		count = 3;
		//Debug.Log(PlayerPersistentData.Instance.TimeAds);
		Debug.Log("Load Level" + levelPlay);
		GameObject levelPrefab = Resources.Load<GameObject>("Levels/Level" + levelPlay);

		if (curLevel)
		{
			Destroy(curLevel.gameObject);
		}

		curLevel = Instantiate(levelPrefab, Vector2.zero, Quaternion.identity).GetComponent<Level>();
		startTimePlay = Time.time;
		UIScreenEvent.Instance.MenuOn();
		if (ads >= 3)
		{
			UnityEvent e = new UnityEvent();

			e.AddListener(() =>
			{

			});
			SkygoBridge.Instance.ShowInterstitial(e);
		}
	}

	[SerializeField] private int levelPlay;

	public int LevelPlay { get => levelPlay; set => levelPlay = value; }


}
