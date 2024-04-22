using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioController : Singleton<AudioController>
{
    [SerializeField] private AudioClip[] audio;

    [SerializeField] private AudioSource sfx;

    public void PlayAudio(int id)
    {
        if(PlayerPersistentData.Instance.Audio == 1)
        {
            
            sfx.PlayOneShot(audio[id]);
        }
    }
     void Interex()
    {
        UnityEvent e = new UnityEvent();

        e.AddListener(() =>
        {
                   
        });
        SkygoBridge.Instance.ShowInterstitial(e);
    }

    //Banner
    //Inter
    //Rewaed
    //AOA

    //void TakeCoin()
    //{


//    UnityEvent e = new UnityEvent();

//    e.AddListener(() =>
//        {

//        });

//SkygoBrigde.instance.ShowRewarded(e, null);
    //}

}
