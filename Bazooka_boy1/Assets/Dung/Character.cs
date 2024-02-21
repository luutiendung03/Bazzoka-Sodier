using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D[] rb;
    public Collider2D[] col;
    public HingeJoint2D[] joints;

    public abstract void CheckDead();

    public abstract IEnumerator Die();

    public  abstract void VictoryAnimation();

    
}
