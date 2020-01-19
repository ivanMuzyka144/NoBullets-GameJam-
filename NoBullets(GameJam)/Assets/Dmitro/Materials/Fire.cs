using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private ParticleSystem particleObject;

    void Start()
    {
        particleObject = GetComponent<ParticleSystem>();
        if (!particleObject.isPlaying)
        {
            particleObject.Play();
        }
    }
}