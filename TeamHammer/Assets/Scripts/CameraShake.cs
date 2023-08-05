using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public float intensity;
    public float shakeTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ShakeCamera(intensity,shakeTime));
    }

    IEnumerator ShakeCamera(float intensity, float shakeTime)
    {
        CinemachineBasicMultiChannelPerlin cine= cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cine.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(shakeTime);
        cine.m_AmplitudeGain = 0f; 
    }
}
