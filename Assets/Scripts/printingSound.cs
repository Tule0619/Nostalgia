using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printingSound : MonoBehaviour
{

    [SerializeField] AudioSource audio;
    public void playSound()
    {
        audio.Play();
    }
}
