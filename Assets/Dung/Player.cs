using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Transform scope;
    public Transform hip;
    public Transform spine;
    public bool isDead;

    public Mesh meshSkinHead;
    public Mesh meshSkinBody;
    public Mesh meshSkinLeg;
    public Material materialOfHead;
    public Material materialOfBody;
    public Material materialOfLeg;

    [SerializeField] private SkinnedMeshRenderer head;
    [SerializeField] private SkinnedMeshRenderer body;
    [SerializeField] private SkinnedMeshRenderer leg;

    [SerializeField] private GameObject gun;
    [SerializeField] private Mesh gunMesh;
    [SerializeField] private Material gunMaterial;

    private bool firstTime = false;
   // private Rigidbody2D[] rb;
    
    public static Player Instance;

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
        firstTime = false;
        isDead = false;
        rb = gameObject.GetComponentsInChildren<Rigidbody2D>();
        col = gameObject.GetComponentsInChildren<Collider2D>();

        transform.eulerAngles = Vector3.zero;

        foreach (HingeJoint2D joint in joints)
        {
            joint.enabled = true;
        }

        foreach (Rigidbody2D rigid in rb)
        {
            rigid.velocity = Vector2.zero;
            rigid.isKinematic = true;
        }

        foreach (Collider2D collider in col)
        {
            collider.enabled = false;
        }

        col[0].enabled = true;
        rb[0].isKinematic = false;
        animator = GetComponent<Animator>();
        
        //animator.enabled = false;

        SetSkin();
        SetGun();

        //gameObject.GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //gameObject.GetComponentsInChildren<Rigidbody2D>().

    }

    public void SetGun()
    {
        //gun = Traveler.Instance.guns[PlayerPersistentData.Instance.GunId];
        gunMesh = Traveler.Instance.gunMesh[PlayerPersistentData.Instance.GunId];
        gunMaterial = Traveler.Instance.material;

        gun.GetComponent<MeshFilter>().mesh = gunMesh;
        gun.GetComponent<MeshRenderer>().material = gunMaterial;
    }

    public void SetSkin()
    {
        meshSkinHead = Traveler.Instance.meshSkinHead[PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Head)];
        meshSkinBody = Traveler.Instance.meshSkinBody[PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Body)];
        meshSkinLeg = Traveler.Instance.meshSkinLeg[PlayerPersistentData.Instance.GetMeshSkin(TypeofSkin.Leg)];

        materialOfHead = Traveler.Instance.material;
        materialOfBody = Traveler.Instance.material;
        materialOfLeg = Traveler.Instance.material;

        head.sharedMesh = meshSkinHead;
        body.sharedMesh = meshSkinBody;
        leg.sharedMesh = meshSkinLeg;

        head.material = materialOfHead;
        body.material = materialOfBody;
        leg.material = materialOfLeg;
    }




    public override IEnumerator Die()
    {

        animator.enabled = true;
        animator.SetBool("Lose", true);
        Debug.Log(animator.enabled);

        //animator.enabled = false;

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

        foreach (HingeJoint2D joint in joints)
        {
            joint.enabled = true;
        }

        yield return new WaitForSeconds(0.1f);

        animator.enabled = false;
        Debug.Log(animator.enabled);


    }

  

    public override void VictoryAnimation()
    {
        foreach (Rigidbody2D rigid in rb)
        {
            rigid.isKinematic = true;
        }

        foreach (Collider2D collider in col)
        {
            collider.enabled = false;
        }
        animator.enabled = true;
        animator.SetBool("Win", true);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(!firstCollide)
        {
            theFirst = collision.gameObject;
            firstCollide = true;
            Debug.Log(collision.gameObject);
        }

        if (collision.gameObject != theFirst)
        {
            CheckDead();
            Debug.Log(collision.gameObject);
        }
    }

    public override void CheckDead()
    {
        if(!isDead)
        {
            isDead = true;
            StartCoroutine(Die());
        }

    }
}
