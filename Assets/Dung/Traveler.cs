using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : Singleton<Traveler>
{
    [SerializeField] public Bullet[] gunPrefabs;
    [SerializeField] public Mesh[] meshSkinHead;
    [SerializeField] public Mesh[] meshSkinBody;
    [SerializeField] public Mesh[] meshSkinLeg;
    [SerializeField] public Material material;
    [SerializeField] public Mesh[] gunMesh;

    //[SerializeField] public GameObject[] guns;

}
