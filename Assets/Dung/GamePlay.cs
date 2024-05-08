using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	public static GamePlay instance;

	public GameObject firstBullet;
	public GameObject secondBullet;
	public GameObject thirdBullet;
	[SerializeField] private Player player;

	[SerializeField] public GameObject dbKillText;
	[SerializeField] public GameObject aceTxt;

	[SerializeField] private Text curLevelTxt;

	public GameObject maxBullet;

    private void Awake()
    {
        if(instance == null)
        {
			instance = this;
        }
    }

    Camera cam;

    //public int count = 3;

    public Bullet bullet;
    public Trajectory trajectory;
    [SerializeField] float pushForce;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    public float a;
    private float c;

    //public Level curLevel;

    private void Start()
    {
		if (player == null)
		{
			player =  FindObjectOfType<Player>();
		}
		Swap();
		cam = Camera.main;
		
    }

    private void Update()
    {
		if (player == null)
		{
			player = FindObjectOfType<Player>();
		}
		curLevelTxt.text = PlayerPersistentData.Instance.CurrentLevel.ToString();
	}

    public void Swap()
    {
		bullet = Traveler.Instance.gunPrefabs[PlayerPersistentData.Instance.GunId];
	}		

    public void OnDrag(PointerEventData eventData)
    {
		if(isDragging)
			OnDrag();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
		if (GameManager.Instance.count > 0)
		{
			isDragging = true;
			OnDragStart();
			//UIScreenEvent.Instance.MenuOff();
		}
	}

    public void OnPointerUp(PointerEventData eventData)
    {
		if(isDragging)
        {
			isDragging = false;
			OnDragEnd();
			GameManager.Instance.count--;
			GameManager.Instance.shoot = true ;
		}

	}

	void OnDragStart()
	{
		//bullet.DesactivateRb();
		startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

		trajectory.Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		//distance = Vector2.Distance(startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * pushForce;

		//just for debug
		Debug.DrawLine(startPoint, endPoint);

		if (direction.y != 0)
			c = direction.x / direction.y;
		a = (-Mathf.Atan(c)) * Mathf.Rad2Deg;

		//if (direction.y >= 0)
		//{

		//	if (direction.x > 0)
		//	{
		//		Player.Instance.spine.localEulerAngles = new Vector3(0, 0, -a) + new Vector3(0, 0, -90);
		//		Player.Instance.hip.localScale = new Vector3(-1, 1, 1);

		//	}
		//	else
		//	{
		//		Player.Instance.spine.localEulerAngles = new Vector3(0, 0, -90 + a);
		//		Player.Instance.hip.localScale = new Vector3(1, 1, 1);
		//		//Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) + new Vector3(0, 0, 90);
		//	}
		//}
		//else
		//{

		//	if (direction.x > 0)
		//	{
		//		Player.Instance.spine.localEulerAngles = new Vector3(0, 0, -a) + new Vector3(0, 0, 90);
		//		Player.Instance.hip.localScale = new Vector3(-1, 1, 1);
		//	}
		//	else
		//	{
		//		Player.Instance.spine.localEulerAngles = new Vector3(0, 0, 90 + a);
		//		Player.Instance.hip.localScale = new Vector3(1, 1, 1);
		//		//Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) - new Vector3(0, 0, 90);
		//	}
		//}

		if (direction.y >= 0)
		{

			if (direction.x > 0)
			{
				player.spine.localEulerAngles = new Vector3(0, 0, -a) + new Vector3(0, 0, -90);
				player.hip.localScale = new Vector3(-1, 1, 1);

			}
			else
			{
				player.spine.localEulerAngles = new Vector3(0, 0, -90 + a);
				player.hip.localScale = new Vector3(1, 1, 1);
				//Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) + new Vector3(0, 0, 90);
			}
		}
		else
		{

			if (direction.x > 0)
			{
				player.spine.localEulerAngles = new Vector3(0, 0, -a) + new Vector3(0, 0, 90);
				player.hip.localScale = new Vector3(-1, 1, 1);
			}
			else
			{
				player.spine.localEulerAngles = new Vector3(0, 0, 90 + a);
				player.hip.localScale = new Vector3(1, 1, 1);
				//Player.Instance.hip.eulerAngles = new Vector3(0, 0, a) - new Vector3(0, 0, 90);
			}
		}

		trajectory.UpdateDots(player.scope.position, force);
	}

	void OnDragEnd()
	{
		//push the ball
		//Bullet newBullet = Instantiate(bullet, Player.Instance.scope.position, Quaternion.identity);
		//newBullet.Push(direction * pushForce);
		PlayerPersistentData.Instance.ScoreProgress(AchievementType.Shoot, 1);

		StartCoroutine(bullet.Shoot(bullet, player.scope.position, direction, pushForce));


		//bullet.Shoot(bullet, Player.Instance.scope.position, direction * pushForce); 

		trajectory.Hide();
	}

	

	//private void BulletCount()
	//{
	//	if (count == 2)
	//		UIManager.Instance.inGamePanel.thirdBullet.SetActive(false);
	//	if (count == 1)
	//		UIManager.Instance.inGamePanel.secondBullet.SetActive(false);
	//	if (count == 0)
	//	{
	//		UIManager.Instance.inGamePanel.firstBullet.SetActive(false);

	//	}

	//}



	//float startTimePlay;


	//public void LoadCurrentLevel()
	//{
	//	bool hasLevel = HasLevelLeft();
	//	if (hasLevel)
	//	{
	//		LoadLevel();
	//	}
	//	else
	//	{
	//		Debug.Log("Het Level");
	//	}
	//}

	//public bool HasLevelLeft()
	//{
	//	return Resources.Load<GameObject>("Levels/Level" + levelPlay);
	//}

	//public void LoadLevel()
	//{
	//	Debug.Log("Load " + levelPlay);
	//	GameObject levelPrefab = Resources.Load<GameObject>("Levels/Level" + levelPlay);

	//	if (curLevel)
	//	{
	//		Destroy(curLevel.gameObject);
	//	}

	//	curLevel = Instantiate(levelPrefab).GetComponent<Level>();
	//	startTimePlay = Time.time;

	//}

	//[SerializeField] private int levelPlay = 1;

	//public int LevelPlay { get => levelPlay; set => levelPlay = value; }
}
