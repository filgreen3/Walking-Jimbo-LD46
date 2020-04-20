using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] protected AudioClip сlip;

    public void PlaySound()
    {
        var audioSource = WorldManager.Instance.WorldAudioSource;
        audioSource.pitch = Random.Range(.7f, 1.5f);
        audioSource.PlayOneShot(сlip);
    }



}
