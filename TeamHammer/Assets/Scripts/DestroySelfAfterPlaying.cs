using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterPlaying : MonoBehaviour
{
    [SerializeField] AnimationClip animation;
    private float time; 
    private void Update()
    {
        time += Time.deltaTime;
        if (time > animation.length)
            Destroy(gameObject);
    }
}
