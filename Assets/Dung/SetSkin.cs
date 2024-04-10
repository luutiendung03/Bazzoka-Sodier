using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : Singleton<SetSkin>
{
    public Mesh meshSkinHead;
    public Mesh meshSkinBody;
    public Mesh meshSkinLeg;
    public Material materialOfHead;
    public Material materialOfBody;
    public Material materialOfLeg;

    [SerializeField] private SkinnedMeshRenderer head;
    [SerializeField] private SkinnedMeshRenderer body;
    [SerializeField] private SkinnedMeshRenderer leg;



    // Start is called before the first frame update
    void Start()
    {
        SetCurrentSkin();
    }

   
    public void SetCurrentSkin()
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
}
