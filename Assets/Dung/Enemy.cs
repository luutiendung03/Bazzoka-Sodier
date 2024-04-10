using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public bool isDead;
    //private Rigidbody2D[] rb;
    //private Collider2D[] col;
    public static Enemy Instance;

    private bool firstCollide = false;

    private GameObject theFirst;

    private void Awake()
    {   
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        firstCollide = false;
        isDead = false;
        col = gameObject.GetComponentsInChildren<Collider2D>();
        rb = gameObject.GetComponentsInChildren<Rigidbody2D>();
        joints = gameObject.GetComponentsInChildren<HingeJoint2D>();
        animator = GetComponent<Animator>();
        //animator.enabled = false;
        
        //foreach(HingeJoint2D joint in joints)
        //{
        //    joint.enabled = false;
        //}

        foreach (Rigidbody2D rigid in rb)
        {
            rigid.isKinematic = true;
        }

        foreach (Collider2D collider in col)
        {
            collider.enabled = false;
        }

        col[0].enabled = true;
        rb[0].isKinematic = false;
    }

    public override IEnumerator Die()
    {
        PlayerPersistentData.Instance.ScoreProgress(AchievementType.KillEnemies, 1);

        
        animator.SetBool("Lose", true);
        Level.Instance.cnt++;
        Debug.Log("kewk");


        Debug.Log("Die");

        animator.enabled = false;
        foreach (Rigidbody2D rigid in rb)
        {
            rigid.velocity = Vector2.zero;
            rigid.isKinematic = false;
        }
        rb[0].isKinematic = true;

        foreach (Collider2D collider in col)
        {
            collider.enabled = true;
        }
        col[0].enabled = false;


        yield return new WaitForSeconds(0.5f);

        //foreach (HingeJoint2D joint in joints)
        //{
        //    joint.enabled = true;
        //}
    }

    public override void VictoryAnimation()
    {
        animator.SetBool("Win", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(!firstCollide)
        {
            theFirst = collision.gameObject;
            firstCollide = true;    
        }

        if(collision.gameObject != theFirst)
        {

            CheckDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckDead();
    }

    public override void CheckDead()
    {
        if (!isDead)
        {
            isDead = true;
            StartCoroutine(Die());
        }
    }
}
