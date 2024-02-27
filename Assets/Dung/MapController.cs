using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject currentMap;
    [SerializeField] private Sprite[] mapSprites;

    private void Start()
    {
        MapChange();
        MapMoverment();
    }

    private void MapChange()
    {
        int mapIndex = PlayerPersistentData.Instance.CurrentLevel / 10;
        currentMap.GetComponent<SpriteRenderer>().sprite = mapSprites[mapIndex];
    }

    private void MapMoverment()
    {
        switch(PlayerPersistentData.Instance.CurrentLevel % 10)
        {
            case 0:
                currentMap.transform.position = new Vector3(17, 0, currentMap.transform.position.z);
                break;

            case 1:
                currentMap.transform.position = new Vector3(-17, 0, currentMap.transform.position.z);
                break;

            case 2:
                currentMap.transform.position = new Vector3(-14, 0, currentMap.transform.position.z);
                break;

            case 3:
                currentMap.transform.position = new Vector3(-10, 0, currentMap.transform.position.z);
                break;

            case 4:
                currentMap.transform.position = new Vector3(-6, 0, currentMap.transform.position.z);
                break;

            case 5:
                currentMap.transform.position = new Vector3(-2, 0, currentMap.transform.position.z);
                break;

            case 6:
                currentMap.transform.position = new Vector3(2, 0, currentMap.transform.position.z);
                break;

            case 7:
                currentMap.transform.position = new Vector3(6, 0, currentMap.transform.position.z);
                break;

            case 8:
                currentMap.transform.position = new Vector3(10, 0, currentMap.transform.position.z);
                break;

            case 9:
                currentMap.transform.position = new Vector3(14, 0, currentMap.transform.position.z);
                break;
        }
    }
}
