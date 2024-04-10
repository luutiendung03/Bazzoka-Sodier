using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGun : Singleton<SetGun>
{

    [SerializeField] private GameObject gun;
    [SerializeField] private Mesh gunMesh;
    [SerializeField] private Material gunMaterial;
    // Start is called before the first frame update
    void start()
    {
        SetCurrentGun();
    }

    public void SetCurrentGun()
    {
        //gun = Traveler.Instance.guns[PlayerPersistentData.Instance.GunId];
        gunMesh = Traveler.Instance.gunMesh[PlayerPersistentData.Instance.GunId];
        gunMaterial = Traveler.Instance.material;

        gun.GetComponent<MeshFilter>().mesh = gunMesh;
        gun.GetComponent<MeshRenderer>().material = gunMaterial;
    }
}
